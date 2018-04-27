using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class UnToot : MonoBehaviour {

	void Update () {
        Destroy(this.gameObject, 0.1f);
    }

    private void OnDestroy()
    {
        print ("I did");
    }
}
