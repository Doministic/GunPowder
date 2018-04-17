using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeBaseHealthBehaviour : MonoBehaviour {

	public int health;
	public Slider healthBarSlider;

    private int minHealth = 0;
    private int maxHealth = 500;

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
			SceneManager.LoadScene("03_Lose_B");
        }
		healthBarSlider.value = health;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "regEnemyBullet")
        {
            health -= 10;
        }
        if(other.gameObject.tag == "Bomb"){
            health -= 25;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
