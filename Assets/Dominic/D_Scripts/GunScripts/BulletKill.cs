using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKill : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Base")
        {
            other.gameObject.SendMessage("TakeDamage", 3);
            Die();
        }
    }

	private void Die(){
		Destroy(gameObject, 0.9f);
	}
}
