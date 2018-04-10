using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIBehaviour : MonoBehaviour {

	[SerializeField]
	private Text timerLabel;

	void Update () {
		timerLabel.text = ForamtTime (GameManager.Instance.TimeRemaining);
	}

	private string ForamtTime(float timeInSeconds){
		return string.Format("{0}:{1:00}", Mathf.FloorToInt(timeInSeconds/60), Mathf.FloorToInt(timeInSeconds % 60));
	}
}
