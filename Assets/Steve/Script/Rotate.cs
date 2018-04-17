using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float speed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var translation = Input.GetAxis("Horizontal")*speed;
        transform.Rotate(Vector2.right, Space.World);

        Debug.Log(translation);
    }
}
