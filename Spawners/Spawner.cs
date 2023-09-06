using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Stats")]
    [Tooltip("The time it takes for the first monster to spawn (Min and Max posible value)")]
    public Vector2 offset;
    [Range(1, 3)]
    [Tooltip("Size of the spheres on which will be the travel point.")]
    public float radius = 1.5f;
    [Range(1, 15)]
    [Tooltip("How often dows monster spawn (Min posible value)")]
    public int minSpawnTime = 5;
    [Range(1, 15)]
    [Tooltip("How often dows monster spawn (Max posible value)")]
    public int maxSpawnTime = 10;
    [Tooltip("The maximum amount of monster tht can be on this row at the same time.")]
    public int maxMonster;
    [Header("GameObjects")]
    public GameObject[] monstersPrefabs;
    public GameObject nodesGroup;

    [HideInInspector]
    public Queue<GameObject> monsterQueue;
    [HideInInspector]
    public GameObject firstMonster;
    private float nextSpawn;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector3 from = transform.position;
        Vector3 to = nodesGroup.transform.GetChild(0).position;

        float gizmoRadius = 0.3f;
        //Draws a line from the spawner to the first point and the sphere
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(from, gizmoRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(from, radius);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(from, to);
        for (int i = 1; i < nodesGroup.transform.childCount; i++)
        {
            from = nodesGroup.transform.GetChild(i - 1).position;
            to = nodesGroup.transform.GetChild(i).position;
            //Draws a line from the last point to the next point and the sphere
            Gizmos.DrawSphere(from, gizmoRadius);
            Gizmos.DrawWireSphere(from, radius);
            Gizmos.DrawLine(from, to);
        }
        Gizmos.DrawSphere(to, gizmoRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(to, new Vector3(radius*1.5f, .5f, 1));
    }
#endif

    void Start()
    {
        nextSpawn = Time.time + Random.Range(offset.x, offset.y);
        monsterQueue = new Queue<GameObject>();
    }

    void Update()
    {
        if (GameManager.instance.IsPlaying && !HordeMax)
        {
            if (Time.time >= nextSpawn)
            {
                if (monsterQueue.Count < maxMonster)
                {
                    SpawnRandom();
                    nextSpawn = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
                }
            }
        }

    }

    private bool HordeMax => SceneMaster.level_Data.playmode == GameManager.PlayMode.Horde && GameManager.instance.monstersEscaped > SceneMaster.level_Data.mision;

    void SpawnRandom()
    {
        int objectToSpawn = Random.Range(0, monstersPrefabs.Length);
        GameObject spawnedObject = Instantiate(monstersPrefabs[objectToSpawn], new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0)) as GameObject;
        monsterQueue.Enqueue(spawnedObject);
        if (firstMonster == null)
        {
            firstMonster = spawnedObject;
        }
        spawnedObject.transform.parent = GameManager.instance.enemiesGroup.transform;
        spawnedObject.GetComponent<Enemy>().mySpawner = this;
    }

    public void SearchFirstMonster()
    {
        firstMonster = null;
        foreach (GameObject monster in monsterQueue)
        {
            if (firstMonster == null || firstMonster.transform.position.z < monster.transform.position.z)
            {
                firstMonster = monster;
            }
        }
    }
}