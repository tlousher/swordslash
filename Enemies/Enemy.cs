﻿using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using Collections;
using Gui;
using Inputs;
using Items;
using Misc;
using UnityEngine;
using Vault;
using Random = UnityEngine.Random;

namespace Enemies
{
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
        [Header("Slash Particles")]
        [SerializeField] private Transform slashParticlesParent;
        [SerializeField] private GameObject goodSlashParticles;
        [SerializeField] private GameObject badSlashParticles;
        
        [Header("Components")]
        public GameObject collectiblePrefab;
        public Material normalMaterial;
        public Material outlineMaterial;
        public GameObject comboText;
        public AnimationClip attackClip;
        public AnimationClip dieClip;

        [HideInInspector]
        public Spawner mySpawner;
        protected bool inRange;
        protected List<Collectible.CollectibleData> collectibles;

        private Transform pathNodes;
        private Vector3 startPosition;
        private Vector3 endPosition;
        private float timePassed;
        private int count;
        private bool moving;
        private bool alive;
        private Animator animator;
        private Vector3 _lastPosition;

        // Variables de animacion
        private readonly int damageTriggerHash = Animator.StringToHash("Damage");
        private readonly int attackTriggerHash = Animator.StringToHash("Attack");
        private readonly int moveClipHash = Animator.StringToHash("Base Layer.Move");
        private readonly int deadTriggerHash = Animator.StringToHash("Dead");
        
        private static Transform _parent;

        private Vector3 GetTarget()
        {
            var nodePosition = pathNodes.GetChild(count).transform.position;
            var yRadius = .5f;
            if (count < pathNodes.childCount - 1)
            {
                yRadius = mySpawner.radius;
            }

            return new Vector3(nodePosition.x + Random.Range(-mySpawner.radius, mySpawner.radius), nodePosition.y + Random.Range(-yRadius, yRadius), nodePosition.z);
        }

        public void SetRandomSpeed() => speed = Random.Range(speed - 1.5f, speed + 2.5f);

        private void Awake()
        {
            // Initializes the collectibles
            collectibles = new List<Collectible.CollectibleData>();
            InitializeCollectibles();

            // Get and assign the animator
            animator = GetComponent<Animator>();
            
            // Set the parent for the collectibles
            if (_parent) return;
            _parent = new GameObject("Collectibles").transform;
            // Set the parent to the same parent as this
            _parent.SetParent(transform.parent);
        }

        private void OnDisable()
        {
            // Remove this enemy as delegate for slashes
            Slasher.OnSlash -= DetectSlash;
        }

        protected virtual void OnEnable()
        {
            // Asign this enemy as delegate for slashes
            Slasher.OnSlash += DetectSlash;
        }
        
        protected static void DiscoverMonster(Monsters.MonsterName discoveryName)
        {
            var monsterData = Monsters.GetData(discoveryName);
            if (monsterData.collectionState == CollectionPrefs.CollectionState.Discovered) return;
            
            CollectionPrefs.SetCollectionState(monsterData.itemID, CollectionPrefs.CollectionState.Discovered);
        }

        protected virtual void InitializeCollectibles()
        {
            //Sets the collectibles that this enemy can drop
        }

        protected virtual void Shoot()
        {
            // Creates an shoot a object when it get's into shooting range
            return;
        }

        protected virtual void ExplodeSpecial()
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
            pathNodes = mySpawner ? mySpawner.nodesGroup.transform : null;
            endPosition = pathNodes ? GetTarget() : transform.position;
            inRange = false;
            //SetRandomSpeed();
            if (CollectionPrefs.GetCollectionState(Monsters.GetData(monsterName).itemID) == CollectionPrefs.CollectionState.Missing)
            {
                GameManager.instance.newMonsters.Add(Monsters.GetData(monsterName));
            }
        }

        protected virtual void Update()
        {
            if(monsterName == Monsters.MonsterName.Training) return;
            moving = animator.GetCurrentAnimatorStateInfo(0).fullPathHash == moveClipHash;

            if (!GameManager.instance.IsPlaying || !alive) return;
            if (mySpawner != null && transform.position.z < mySpawner.firstMonster.transform.position.z)
            {
                mySpawner.firstMonster = gameObject;
            }
            if ((mySpawner == null || mySpawner.firstMonster.Equals(gameObject)) && transform.position.y < Player.instance.sword.RangePositionY)
            {
                inRange = true;
                ShowAura();
            }
            else
            {
                inRange = false;
                HideAura();
            }

            if (pathNodes != null)
            {
                Move();
            }

            GetComponent<SpriteRenderer>().sortingOrder = Mathf.FloorToInt(transform.position.y) * -1;
        }

        private int QueuePosition => System.Array.IndexOf(mySpawner.monsterQueue.ToArray(), gameObject);

        private void Move()
        {
            if (!moving) return;
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
                var lerp = Vector3.Lerp(startPosition, endPosition, timePassed);
                transform.position = new Vector3(lerp.x, lerp.y, lerp.z);
                timePassed += Mathf.Clamp(Time.deltaTime * (1 / Vector3.Distance(startPosition, endPosition)) * (speed / 5 + 1), 0, 1);
            }
        }

        private void Damage(Slasher.SlashDirections direction)
        {
            healthPoints--;
            try
            {
                var parameters = animator.parameters;
                if (parameters.Any(parameter => parameter.name == $"Damage_{direction}"))
                {
                    // Set the parameter "Damage" + direction to true
                    animator.SetTrigger($"Damage_{direction}");
                }
                else if (parameters.Any(parameter => parameter.nameHash == damageTriggerHash))
                {
                    animator.SetTrigger(damageTriggerHash);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void DetectSlash(Vector2 rawDirection)
        {
            if (!alive || !isActiveAndEnabled) return;

            var slashDirection = IsValidSlash(rawDirection);
            var goodDirection = slashDirection != Slasher.SlashDirections.Bad;

            if (inRange)
            {
                var slashParticles = Instantiate(goodDirection ? goodSlashParticles : badSlashParticles, Vector3.zero, Quaternion.identity, slashParticlesParent);
                
                slashParticles.transform.localPosition = Vector3.zero;
                slashParticles.transform.localRotation = Quaternion.Euler(0, 0, Slasher.SlashDirectionToAngle(slashDirection));
                Destroy(slashParticles, 1.3f);
            }

            if (!inRange || !goodDirection) return;
            Damage(slashDirection);
            if (healthPoints >= 1) return;
            //Updates the score and kills count on the gamemaster
            GameManager.instance.score += score;
            GameManager.instance.monstersKilled++;
            //Finally the monster dies
            Die();
        }

        private Slasher.SlashDirections IsValidSlash(Vector2 slashDirection)
        {
            foreach (var validateDirection in validDirections)
            {
                switch (validateDirection)
                {
                    case Slasher.SlashDirections.Right:
                        if (Slasher.IsRightSlash(slashDirection)) return Slasher.SlashDirections.Right;
                        break;
                    case Slasher.SlashDirections.UpRight:
                        if (Slasher.IsUpRightSlash(slashDirection)) return Slasher.SlashDirections.UpRight;
                        break;
                    case Slasher.SlashDirections.Up:
                        if (Slasher.IsUpSlash(slashDirection)) return Slasher.SlashDirections.Up;
                        break;
                    case Slasher.SlashDirections.UpLeft:
                        if (Slasher.IsUpLeftSlash(slashDirection)) return Slasher.SlashDirections.UpLeft;
                        break;
                    case Slasher.SlashDirections.Left:
                        if (Slasher.IsLeftSlash(slashDirection)) return Slasher.SlashDirections.Left;
                        break;
                    case Slasher.SlashDirections.DownLeft:
                        if (Slasher.IsDownLeftSlash(slashDirection)) return Slasher.SlashDirections.DownLeft;
                        break;
                    case Slasher.SlashDirections.Down:
                        if (Slasher.IsDownSlash(slashDirection)) return Slasher.SlashDirections.Down;
                        break;
                    case Slasher.SlashDirections.DownRight:
                        if (Slasher.IsDownRightSlash(slashDirection)) return Slasher.SlashDirections.DownRight;
                        break;
                    case Slasher.SlashDirections.Bad:
                        return Slasher.VectorToSlashDirections(slashDirection);
                    case Slasher.SlashDirections.Joker:
                        return Slasher.SlashDirections.Joker;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return Slasher.SlashDirections.Bad;
        }

        protected virtual void Explode()
        {
            //Plays the die animation
            try
            {
                animator.SetTrigger(attackTriggerHash);
            }
            catch (Exception)
            {
                // ignored
            }

            //Invokes the attack method after the animation ends
            Invoke(nameof(Attack), attackClip.length - attackDelay);
        }

        protected virtual void Attack()
        {
            if (!alive) return;
            Player.instance.Damage(power);
            ExplodeSpecial();
            GameManager.instance.monstersEscaped++;

            RemoveEnemy(attackDelay);
        }

        internal virtual void Die()
        {
            if (!alive) return;
            if (transform == null)
            {
                Debug.Log("The monster is null");
                return;
            }
            _lastPosition = transform.position;
            // Plays the die animation
            if (animator.parameters.Any(parameter => parameter.nameHash == deadTriggerHash))
            {
                animator.SetTrigger(deadTriggerHash);
            }

            // Controls the collectibles drop
            DropCollectible();
            // Adds the combo power
            ComboManager.instance.AddCombo();
            //Adds this monster kill to the achievement
            AchievementCounterPlus();

            // Removes the enemy from the scene
            RemoveEnemy(dieClip.length);
            ShowCombo();
        }

        private void ShowCombo()
        {
            var combo = ComboManager.Combo;
            if (combo < 2) return;
            var newCombo = Instantiate(comboText, transform.parent);
            newCombo.transform.localPosition = transform.localPosition;
            newCombo.GetComponentInChildren<TMPro.TextMeshPro>().text = $"x{combo}";
            Destroy(newCombo, 0.6f);
        }

        private void RemoveEnemy(float extraTime = 0)
        {
            if (!alive) return;
            //Manage the Spawner monster controll
            try
            {
                mySpawner.monsterQueue.Dequeue();
            }
            catch (InvalidOperationException)
            {
                // ignored
            }
            //Hides the slash aura
            HideAura();
            //Highlights the new monster
            mySpawner.SearchFirstMonster();
            alive = false;

            //Destroys the enemy in some amount of time
            Destroy(gameObject, extraTime);
        }

        protected virtual void AchievementCounterPlus()
        {
            //Increase the monster kill achievement
            switch (monsterName)
            {
                case Monsters.MonsterName.Water:
                    PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.WaterSlayerI);
                    break;
                case Monsters.MonsterName.Wood:
                    PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.WoodSlayerI);
                    break;
                case Monsters.MonsterName.Fire:
                    PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.FireSlayerI);
                    break;
                case Monsters.MonsterName.Slime:
                    PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.SlimeSlayerI);
                    break;
                case Monsters.MonsterName.Training:
                    PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.TrainingManiac);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void DropCollectible()
        {
            if (monsterName == Monsters.MonsterName.Training) return;
            //Spins the roulette to see what rarity will have the dropped collectible
            var rarity = Collectible.CollectibleData.GetRandomRarity();

            if (collectibles.Count <= 0 || rarity == Collectible.CollectibleData.Rarity.NoDrop) return;
            //Select all collectibles with the selected rarity
            var orbs = collectibles.Where(orb => orb.rarity == rarity).ToList();

            if (orbs.Count <= 0) return;
            //Select a random collectible from the selected rarities
            var collectible = orbs[Mathf.RoundToInt(Random.Range(0, orbs.Count - 1))];

            //Instatiate a random collectible from that rarity
            var prefab = Instantiate(collectiblePrefab, _parent);
            prefab.transform.localPosition = _lastPosition;
            prefab.GetComponent<Collectible>().data = collectible;
            prefab.GetComponent<SpriteRenderer>().sprite = collectible.sprite;
            //Put that collectible inside the Queue in the gamemaster
            GameManager.instance.collectibles.Enqueue(collectible);
            GameManager.instance.collectiblesStacks.SendMessage("CollectibleDrop", collectible.sprite);
            
            // Add the collectible to the collection
            if (CollectionPrefs.GetCollectionState(collectible.itemID) !=
                CollectionPrefs.CollectionState.Missing) return;
            
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.Gatherer);
            CollectionPrefs.SetCollectionState(collectible.itemID, CollectionPrefs.CollectionState.Discovered);
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
}
