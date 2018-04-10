using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKill : MonoBehaviour {

	public void Start()
	{
		Destroy(gameObject, 0.75f);
	}
}
