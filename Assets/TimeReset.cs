using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReset : MonoBehaviour {

	// Use this for initialization

	GameManager gameManager;
	private void OnMouseDown()
	{
		gameManager.TimeRemaining = 182;
	}
}
