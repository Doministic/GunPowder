using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyBehaviour : MonoBehaviour
{
    public GameObject flyingEnemy;
    public GameObject bombEnemy;
    public GameObject golemEnemy;
    // public GameObject protectorEnemy;
    public GameObject runtEnemy;

    public GameObject leftBombSpawn;
    public GameObject rightBombSpawn;
    public GameObject leftGolemSpawn;
    public GameObject rightGolemSpawn;
    // public GameObject leftProtectorSpawn;
    // public GameObject rightProtectorSpawn;
    public GameObject leftRuntSpawn;
    public GameObject rightRuntSpawn;
    public List<GameObject> enemySpawnLocations = new List<GameObject>();
    public float spawnWait;
    public float waveWait;
    public int minTotalEnemyCount = 40;
    public int maxTotalEnemyCount = 50;

    private float startWait = 1.5f;
    private int enemyCount;
    private int index;
    private int totalEnemyCount;
    private int waveCount;
    private int totalWaveCount;


    IEnumerator SpawnEnemyCoroutine()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i <= totalEnemyCount; i++)
            {
                if (enemyCount >= 0)
                {
                    SpawnFlyingEnemy();
                    yield return new WaitForSeconds(spawnWait);
                }
                if (enemyCount >= 9)
                {
                    SpawnBombEnemy();
                    yield return new WaitForSeconds(spawnWait);
                }
                if (enemyCount >= 19)
                {
                    SpawnRuntEnemy();
                    yield return new WaitForSeconds(spawnWait);
                }
                if(enemyCount >= 50){
                    SpawnGolemEnemy();
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    void Start()
    {
        totalEnemyCount = Random.Range(minTotalEnemyCount, maxTotalEnemyCount);
        StartCoroutine(SpawnEnemyCoroutine());
    }

    void Update()
    {
        index = Random.Range(0, enemySpawnLocations.Count);
        if (enemyCount > 9 && enemySpawnLocations.Count == 1)
        {
            enemySpawnLocations.Add(rightBombSpawn);
            enemySpawnLocations.Add(leftBombSpawn);
        }
        if (enemyCount > 19 && enemySpawnLocations.Count == 3){
            enemySpawnLocations.Remove(rightBombSpawn);
            enemySpawnLocations.Remove(leftBombSpawn);
            enemySpawnLocations.Add(rightRuntSpawn);
            enemySpawnLocations.Add(leftRuntSpawn);
        }
        if(enemyCount > 30 && enemySpawnLocations.Count == 3)
        if(enemyCount > 50 && enemySpawnLocations.Count == 3){
            enemySpawnLocations.Remove(rightRuntSpawn);
            enemySpawnLocations.Remove(leftRuntSpawn);
            enemySpawnLocations.Add(rightGolemSpawn);
            enemySpawnLocations.Add(leftGolemSpawn);
        }
    }

    void SpawnFlyingEnemy()
    {
        if (index == 0)
        {
            float minX = -10.0f;
            float maxX = 10.0f;
            float randomX = Random.Range(minX, maxX);
            Vector2 spawnPoint0 = new Vector3(randomX, enemySpawnLocations[0].transform.position.y, -2);
            Instantiate(flyingEnemy, spawnPoint0, Quaternion.identity);
        }

        enemyCount++;
    }

    void SpawnBombEnemy()
    {
        if (index == 1)
        {
            Instantiate(bombEnemy, rightBombSpawn.transform.position, Quaternion.identity);
        }
        else if (index == 2)
        {
            Instantiate(bombEnemy, leftBombSpawn.transform.position, Quaternion.identity);
        }
        enemyCount++;
    }

    void SpawnRuntEnemy(){
        if (index == 1 || index == 3)
        {
            Instantiate(runtEnemy, rightRuntSpawn.transform.position, Quaternion.identity); 
        }
        else if (index == 2 || index == 4)
        {
            Instantiate(runtEnemy, leftRuntSpawn.transform.position, Quaternion.identity);
        }
        enemyCount++;
    }
    
    void SpawnGolemEnemy()
    {
        if (index == 1 || index == 3)
        {
            float transNew;
            Instantiate(golemEnemy, rightGolemSpawn.transform.position, Quaternion.identity);
            if(transform.position.x > 0){
                transNew = transform.rotation.x * -1;
                golemEnemy.transform.rotation = new Quaternion(0, 0.9f, 0, 0);
            }
        }
        else if (index == 2 || index == 4)
        {
            Instantiate(golemEnemy, leftGolemSpawn.transform.position, Quaternion.identity);
        }
        enemyCount++;
    }
}
