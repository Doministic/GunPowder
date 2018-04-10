using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyBehaviour : MonoBehaviour {


	public GameObject enemyToSpawn;
	public List<GameObject> enemySpawnLocations = new List<GameObject>();
	public float startWait;
	public float spawnWait;
	public float waveWait;
	public int minEnemyCount = 10;
	public int maxEnemyCount = 20;

	private int index;
	private int enemyCount;
	private int waveCount;


	IEnumerator SpawnEnemyCoroutine(){	
		
		enemyCount = Random.Range(minEnemyCount, maxEnemyCount);
		yield return new WaitForSeconds(startWait);
		while (true){
			for(int i = 0; i <= enemyCount; i++){
				SpawnEnemy();
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}

	}
	void Start()
	{	
		StartCoroutine(SpawnEnemyCoroutine());	
	}
	void Update()
	{
		index = Random.Range(0, enemySpawnLocations.Count);
	}
	void SpawnEnemy(){
		if (index == 0){
			float minX = -10.0f;
			float maxX = 10.0f;
			float randomX = Random.Range(minX, maxX);
			Vector2 spawnPoint0 = new Vector3(randomX, enemySpawnLocations[0].transform.position.y, -2);
			Instantiate(enemyToSpawn, spawnPoint0, Quaternion.identity);
		}
		else if (index == 1){
			float minY = 0.0f;
			float maxY = 10.0f;
			float randomY = Random.Range(minY, maxY);
			Vector2 spawnPoint1 = new Vector3(enemySpawnLocations[1].transform.position.x, randomY, -2);
			Instantiate(enemyToSpawn, spawnPoint1, Quaternion.identity);				
		}
		else if (index == 2){
			float minY = 0.0f;
			float maxY = 10.0f;
			float randomY = Random.Range(minY, maxY);
			Vector2 spawnPoint2 = new Vector3(enemySpawnLocations[2].transform.position.x, randomY, -2);
			Instantiate(enemyToSpawn, spawnPoint2, Quaternion.identity);
		}
	}		
}
