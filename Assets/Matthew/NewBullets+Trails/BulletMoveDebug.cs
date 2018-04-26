using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate (new Vector3(0.0f, 3.0f, 0.0f) * Time.deltaTime);
	}
}
