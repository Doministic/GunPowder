using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyBehaviour : MonoBehaviour
{
    public GameObject flyingEnemy;
    public GameObject bombEnemy;
    public GameObject golemEnemy;
    // public GameObject protectorEnemySpawn;
    // public GameObject runtEnemySpawn;

    public GameObject leftBombSpawn;
    public GameObject rightBombSpawn;
    public GameObject leftGolemSpawn;
    public GameObject rightGolemSpawn;
    // public GameObject leftProtectorSpawn;
    // public GameObject rightProtectorSpawn;
    // public GameObject leftRuntSpawn;
    // public GameObject rightRuntSpawn;
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
                }
                if (enemyCount >= 10)
                {
                    SpawnBombEnemy();
                }
                if (enemyCount >= 20)
                {
                    SpawnGolemEnemy();
                }
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            //WaveChange();
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
            enemySpawnLocations.Add(rightGolemSpawn);
            enemySpawnLocations.Add(leftGolemSpawn);
        }
        //Debug.Log("The enemy count is " + enemyCount);
    }

    void WaveChange()
    {
        waveCount++;
        waveWait += 5;
        minTotalEnemyCount += 10;
        maxTotalEnemyCount += 20;
        spawnWait -= 1.5f;
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

    void SpawnGolemEnemy()
    {
        if (index == 1 || index == 3)
        {
            float transNew;
            Instantiate(golemEnemy, rightGolemSpawn.transform.position, Quaternion.identity);
            if(transform.position.x > 0){
                transNew = transform.rotation.x * -1;
                golemEnemy.transform.rotation = new Quaternion(0, -1, 0, .9f);
            }
        }
        else if (index == 2 || index == 4)
        {
            Instantiate(golemEnemy, leftGolemSpawn.transform.position, Quaternion.identity);
        }
        enemyCount++;
    }
}
