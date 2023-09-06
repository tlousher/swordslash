using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int healthPoints = 1;
    public int power = 1;
    public int score = 10;
    [Tooltip("The time it has to wait after the attack before being destroyed.")]
    public float attackDelay = .2f;
    public Monsters.MonsterName monsterName;
    [Range(2, 8)]
    public float speed = 2;
    public List<Slasher.SlashDirections> validDirections;
    [Header("Components")]
    public GameObject collectiblePrefab;
    public Material normalMaterial;
    public Material outlineMaterial;
    public AnimationClip attackClip;
    public AnimationClip dieClip;

    [HideInInspector]
    public Spawner mySpawner;
    protected bool inRange;
    protected List<Collectible.Collectible_Data> collectibles;

    private Transform pathNodes;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float timePassed;
    private int count;
    private bool moving;
    private bool alive;
    private Animator animator;

    // Variables de animacion
    readonly int damageTriggerHash = Animator.StringToHash("Damage");
    readonly int attackTriggerHash = Animator.StringToHash("Attack");
    readonly int moveClipHash = Animator.StringToHash("Base Layer.Move");
    readonly int deadTriggerHash = Animator.StringToHash("Die");

    private Vector3 GetTarget()
    {
        Vector3 nodePosition = pathNodes.GetChild(count).transform.position;
        float YRadius = .5f;
        if (count < pathNodes.childCount - 1)
        {
            YRadius = mySpawner.radius;
        }

        return new Vector3(nodePosition.x + Random.Range(-mySpawner.radius, mySpawner.radius), nodePosition.y + Random.Range(-YRadius, YRadius), nodePosition.z);
    }

    public void SetRandomSpeed() => speed = Random.Range(speed - 1.5f, speed + 2.5f);

    private void Awake()
    {
        // Initializes the collectibles
        collectibles = new List<Collectible.Collectible_Data>();
        InitializeCollectibles();

        // Asign this enemy as delegate for slashes
        Slasher.OnSlash += DetectSlash;

        // Get and assign the animator
        animator = GetComponent<Animator>();
    }

    protected virtual void InitializeCollectibles()
    {
        //Sets the collectibles that this enemy can drop
    }

    public virtual void Shoot()
    {
        // Creates an shoot a object when it get's into shooting range
        return;
    }

    public virtual void ExplodeSpecial()
    {
        // Activate a special ability when the moster expolodes
        return;
    }

    private void Start()
    {
        timePassed = 0;
        count = 0;
        moving = true;
        alive = true;
        startPosition = transform.position;
        pathNodes = mySpawner.nodesGroup.transform;
        endPosition = GetTarget();
        inRange = false;
        //SetRandomSpeed();
        if (CollectionPrefs.GetCollectionState(Monsters.GetData(monsterName).itemID) == CollectionPrefs.CollectionState.Missing)
        {
            GameManager.instance.newMonsters.Add(Monsters.GetData(monsterName));
        }
    }

    private void Update()
    {
        moving = animator.GetCurrentAnimatorStateInfo(0).fullPathHash == moveClipHash;

        if (GameManager.instance.IsPlaying && alive)
        {
            if (transform.position.z < mySpawner.firstMonster.transform.position.z)
            {
                mySpawner.firstMonster = gameObject;
            }
            if (mySpawner.firstMonster.Equals(gameObject) && transform.position.y < Player.instance.sword.RangePositionY)
            {
                inRange = true;
                ShowAura();
            }
            else
            {
                inRange = false;
                HideAura();
            }

            Move();

            GetComponent<SpriteRenderer>().sortingOrder = Mathf.FloorToInt(transform.position.y) * -1;
        }
    }

    private int QueuePosition => System.Array.IndexOf(mySpawner.monsterQueue.ToArray(), gameObject);

    private void Move()
    {
        if (moving)
        {
            if (timePassed >= 1)
            {
                if (count + 1 == pathNodes.childCount)
                {
                    moving = false;
                    Explode();
                }
                else
                {
                    count++;
                    startPosition = endPosition;
                    endPosition = GetTarget();
                    timePassed = 0;
                }
            }
            else
            {
                Vector3 lerp = Vector3.Lerp(startPosition, endPosition, timePassed);
                transform.position = new Vector3(lerp.x, lerp.y, lerp.z);
                timePassed += Mathf.Clamp(Time.deltaTime * (1 / Vector3.Distance(startPosition, endPosition)) * (speed / 5 + 1), 0, 1);
            }
        }
    }

    private void Damage()
    {
        healthPoints--;
        try
        {
            animator.SetTrigger(damageTriggerHash);
        }
        catch (System.Exception) { }
    }

    private void DetectSlash(Slasher.SlashDirections direction)
    {
        if (alive)
        {
            bool goodDirection = validDirections.Contains(Slasher.SlashDirections.Joker) || validDirections.Contains(direction);

            if (inRange && goodDirection)
            {
                Damage();
                if (healthPoints < 1)
                {
                    //Updates the score and kills count on the gamemaster
                    GameManager.instance.score += score;
                    GameManager.instance.monstersKilled++;
                    //Finally the monster dies
                    Die();
                }
            }
        }
    }

    public virtual void Explode()
    {
        //Plays the die animation
        try
        {
            animator.SetTrigger(attackTriggerHash);
        }
        catch (System.Exception) { }

        //Invokes the attack method after the animation ends
        Invoke("Attack", attackClip.length - attackDelay);
    }

    protected virtual void Attack()
    {
        if (alive)
        {
            Player.instance.Damage(power);
            ExplodeSpecial();
            GameManager.instance.monstersEscaped++;

            RemoveEnemy(attackDelay);
        }
    }

    protected void Die()
    {
        if (alive)
        {
            // Plays the die animation
            try
            {
                animator.SetTrigger(deadTriggerHash);
            }
            catch (System.Exception) { }

            // Controlls the collectibles drop
            DropCollectible();
            // Adds the combo power
            ComboManager.instance.AddCombo();
            //Adds this monster kill to the achievement
            AchievementCounterPlus();

            // Removes the enemy from the scene
            RemoveEnemy(dieClip.length);
        }
    }

    private void RemoveEnemy(float extraTime = 0)
    {
        if (alive)
        {
            //Manage the Spawner monster controll
            mySpawner.monsterQueue.Dequeue();
            //Hides the slash aura
            HideAura();
            //Highlights the new monster
            mySpawner.SearchFirstMonster();
            alive = false;

            //Destroys the enemy in some amount of time
            Destroy(gameObject, extraTime);
        }
    }

    protected virtual void AchievementCounterPlus()
    {
        //Increase the monster kill achievement
        switch (monsterName)
        {
            case Monsters.MonsterName.Water:
                PlayerPrefs2.IncreaseAchievementProgress(Achievements.AchievementID(Achievements.AchievementName.WaterSlayerI));
                break;
            case Monsters.MonsterName.Wood:
                PlayerPrefs2.IncreaseAchievementProgress(Achievements.AchievementID(Achievements.AchievementName.WoodSlayerI));
                break;
            case Monsters.MonsterName.Fire:
                PlayerPrefs2.IncreaseAchievementProgress(Achievements.AchievementID(Achievements.AchievementName.FireSlayerI));
                break;
            case Monsters.MonsterName.Slime:
                PlayerPrefs2.IncreaseAchievementProgress(Achievements.AchievementID(Achievements.AchievementName.SlimeSlayerI));
                break;
        }
    }

    private void DropCollectible()
    {
        //Spins the roulette to see what rarity will have the dropped collectible
        Collectible.Collectible_Data.Rarity rarity = Collectible.Collectible_Data.GetRandomRarity();

        if (collectibles.Count > 0 && rarity != Collectible.Collectible_Data.Rarity.NoDrop)
        {
            //Select all collectibles with the selected rarity
            List<Collectible.Collectible_Data> orbs = new List<Collectible.Collectible_Data>();
            foreach (Collectible.Collectible_Data orb in collectibles)
            {
                if (orb.rarity == rarity)
                {
                    orbs.Add(orb);
                }
            }

            if (orbs.Count > 0)
            {
                //Select a random collectible from the selected rarities
                Collectible.Collectible_Data collectible = orbs[Mathf.RoundToInt(Random.Range(0, orbs.Count - 1))];

                //Instatiate a random collectible from that rarity
                GameObject prefab = Instantiate(collectiblePrefab, transform.parent);
                prefab.transform.localPosition = transform.localPosition;
                prefab.GetComponent<Collectible>().data = collectible;
                prefab.GetComponent<SpriteRenderer>().sprite = collectible.sprite;
                //Put that collectible inside the Queue in the gamemaster
                GameManager.instance.collectibles.Enqueue(collectible);
                GameManager.instance.collectiblesStacks.SendMessage("CollectibleDrop", collectible.sprite);
            }
        }
    }

    protected void ShowAura()
    {
        GetComponent<SpriteRenderer>().material = outlineMaterial;
    }

    protected void HideAura()
    {
        GetComponent<SpriteRenderer>().material = normalMaterial;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShootingTrigger"))
        {
            Shoot();
        }
    }
}
