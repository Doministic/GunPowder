using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLifeBehaviour : MonoBehaviour
{
    public int health;
    public Slider healthBarSlider;

    private int minHealth = 0;
    private int maxHealth = 350;

    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= minHealth)
        {
            Die();
        }
        healthBarSlider.value = health;
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
