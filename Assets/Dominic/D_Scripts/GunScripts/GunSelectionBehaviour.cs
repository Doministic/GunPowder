using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelectionBehaviour : MonoBehaviour {
	public bool mouseSeen;
	public bool isSelected;
	
	void Start () {
		mouseSeen = false;
		isSelected = false;		
	}
	
	private void OnMouseEnter()
	{
		mouseSeen = true;		
	}

	private void OnMouseExit()
	{
		mouseSeen = false;
	}

	private void OnMouseDown()
	{
		if(isSelected == false){
			isSelected = true;
			GetComponentInChildren<GunBehaviour>().ReadyToMove();
		}
		else{
			isSelected = false;
			GetComponentInChildren<GunBehaviour>().ReadyToMove();
		}
	}

	public void ClearSelection(){
		isSelected = false;
	}
}
