using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletTrail : MonoBehaviour {

    public GameObject toot;
    public GameObject offset;


    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnToot" , 0f, 0.02f);
	}
	
	// Update is called once per frame
	void Update () {
        //SpawnToot();
	}

    void SpawnToot() {
        //Instantiate(toot, new Vector2 (transform.position.x, transform.position.y - .01f),Quaternion.identity);
        GameObject bullet = Instantiate(toot, toot.transform.position + offset.transform.position, transform.rotation) as GameObject;
    }
}
