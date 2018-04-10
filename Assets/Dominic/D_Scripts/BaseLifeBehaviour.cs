using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLifeBehaviour : MonoBehaviour
{
    public int health;
	public Slider healthBarSlider;

    private int minHealth = 0;
    private int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            health -= 25;
        }
        if (health <= minHealth)
        {
            Die();
        }
		healthBarSlider.value = health;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "regEnemyBullet")
        {
            health -= 10;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
