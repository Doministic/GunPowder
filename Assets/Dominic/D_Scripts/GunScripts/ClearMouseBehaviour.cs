using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMouseBehaviour : MonoBehaviour {

	void OnMouseDown()
	{
		BroadcastMessage("ClearSelection");
	}
}
