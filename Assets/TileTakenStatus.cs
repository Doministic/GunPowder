using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTakenStatus : MonoBehaviour
{

    public bool tileTaken;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
	void OnMouseDown()
	{
	 	
	}
	void OnTriggerStay(Collider2D other)
	{
		if (other.gameObject.tag == "turret")
		{
			tileTaken = true;
		}
		else 
		{
			tileTaken = false;
		}
	}
}
