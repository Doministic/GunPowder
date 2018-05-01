using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : MonoBehaviour {
    public GameObject shieldEffect;
    public GameObject SpawnShieldEffect;
    private GameObject[] killemALL;

    // Use this for initialization
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Protector")
        {
            Instantiate(shieldEffect, SpawnShieldEffect.transform.position, Quaternion.identity);
            killemALL = GameObject.FindGameObjectsWithTag("Shield");
            for (int i = 5; i < killemALL.Length; i++)
            {
                Destroy(killemALL[i].gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void OnTriggerExit2D(Collider2D other)
    {
            Destroy(GameObject.Find("ShieldEffect(Clone)"));
            //CancelInvoke();
	}
}
