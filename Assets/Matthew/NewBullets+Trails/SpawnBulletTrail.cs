using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletTrail : MonoBehaviour {

    public GameObject toot;


    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnToot" , 0f, 0.00002f);
	}
	
	// Update is called once per frame
	void Update () {
        //SpawnToot();
	}

    void SpawnToot() {
        Instantiate(toot, new Vector2 (transform.position.x, transform.position.y - .01f),Quaternion.identity);
    }
}
