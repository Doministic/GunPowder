using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public void Start()
    {
        Invoke("Spawn", 0.2f);
    }
	//use Random.Range() to set a GameObject's x position
	
	private const float MIN_X = -3.4f;
    private const float MAX_X = 3.4f;

    public void Spawn()
    {
        transform.position = new Vector3(Random.Range(MIN_X, MAX_X), Random.Range(MIN_X, MAX_X), transform.position.z);
        Debug.Log(transform.position.x);
        Invoke("Spawn", 0.2f);
    }
}
