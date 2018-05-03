using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeBaseHealthBehaviour : MonoBehaviour
{

    public int health = 500;
    public Slider healthBarSlider;

    private int maxHealth = 500;

    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthBarSlider.value = health;
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }

    void Die()
    {
        Destroy(gameObject, 0.1f);
    }
}
