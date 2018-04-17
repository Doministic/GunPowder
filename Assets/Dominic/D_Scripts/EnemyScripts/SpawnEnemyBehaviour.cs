using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyBehaviour : MonoBehaviour
{
    public GameObject flyingEnemySpawn;
    public GameObject bombEnemySpawn;
    // public GameObject golemEnemySpawn;
    // public GameObject protectorEnemySpawn;
    // public GameObject runtEnemySpawn;
    public List<GameObject> enemySpawnLocations = new List<GameObject>();
    public float startWait;
    public float spawnWait;
    public float waveWait;
    public int minTotalEnemyCount = 40;
    public int maxTotalEnemyCount = 50;

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
                if (totalEnemyCount >= 0)
                {
                    SpawnFlyingEnemy();
                }
                if (totalEnemyCount >= 10)
                {
                    SpawnBombEnemy();
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
        index = Random.Range(0, enemySpawnLocations.Count - 1);
    }

	void WaveChange(){
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
            Instantiate(flyingEnemySpawn, spawnPoint0, Quaternion.identity);
        }
        enemyCount++;
    }

    void SpawnBombEnemy()
    {
        if (index == 1)
        {
            Instantiate(bombEnemySpawn, enemySpawnLocations[3].transform.position, Quaternion.identity);
        }
        else if (index == 2)
        {
            Instantiate(bombEnemySpawn, enemySpawnLocations[4].transform.position, Quaternion.identity);
        }
        enemyCount++;
    }

    void SpawnGolem()
    {
        enemyCount++;
    }
}
