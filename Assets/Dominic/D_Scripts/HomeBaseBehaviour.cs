using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBaseBehaviour : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		SendMessage("Die");
	}
}
