using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementBehavior : MonoBehaviour {

	public Transform targetObject;
	public float maxMovementSpeed = 7.5f;
	public float minMovementSpeed = 3.5f;
	
	
	private float step;

	void Start () {
		step = Random.Range(minMovementSpeed, maxMovementSpeed);
		Debug.Log(step);
		StartCoroutine(MoveEnemy());
	}

	IEnumerator MoveEnemy(){
		while(transform.position != targetObject.position){
			transform.position = Vector3.MoveTowards(transform.position, targetObject.position, step);
			yield return null;
		}
	}

	public void OnCollisionEnter(Collision otherCollider){
		if(otherCollider.gameObject.tag == "HomeBase"){
			Debug.Log("Object Destroyed");
			Destroy(gameObject);
		}
	}
}
