using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnToot : MonoBehaviour {
    public GameObject yaoo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, 0.5f);
    }

    private void OnDestroy()
    {
        print ("I did");
    }
}
