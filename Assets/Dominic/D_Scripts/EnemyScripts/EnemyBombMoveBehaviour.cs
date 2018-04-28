using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombMoveBehaviour : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float stoppingDistance = 0.5f;
    
    void Start()
    {
        StartCoroutine("MoveTo");
    }

    IEnumerator MoveTo()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, ClosestEnemy().transform.position, movementSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public GameObject ClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Base");
        GameObject closestEnemy = gos[0];
        Vector3 position = gos[0].transform.position;
        foreach (GameObject go in gos)
        {
            Vector2 diff = go.transform.position - position;
            if (Vector2.Distance(diff, transform.position) > Vector2.Distance(closestEnemy.transform.position, transform.position))
            {
                closestEnemy = gos[0];
            }
        }
        return closestEnemy;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Base")
        {
            StopCoroutine("MoveTo");
            other.gameObject.SendMessage("TakeDamage", 17);
            Debug.Log("I should be dead");
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
