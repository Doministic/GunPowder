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
        
		healthBarSlider.value = health;
    }

    public void TakeDamage(int damageTaken){
        Debug.Log("damage taken");
        health -= damageTaken;
        if (health <= minHealth)
        {
            Die();
        }
    }

    void Die()
    {
        Time.timeScale = 0;
        Destroy(gameObject, 0.5f);
    }

    private void OnDestroy()
    {
    	SceneManager.LoadScene("03_Lose_B");
    }


}
