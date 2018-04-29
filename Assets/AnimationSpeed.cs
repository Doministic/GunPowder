using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour {

	// Use this for initialization
	public float speed;

	void Start () 
	{
		gameObject.GetComponent<Animator>().speed = speed;
	}
}
