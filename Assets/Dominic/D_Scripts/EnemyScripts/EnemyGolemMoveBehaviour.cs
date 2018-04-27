using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGolemMoveBehaviour : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public float stoppingDistance = 1.0f;

    private Animator anim;
    private bool attack;
    private int speed;



    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("MoveTo");
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, ClosestEnemy().transform.position);
        if (distanceToTarget <= stoppingDistance)
        {
			anim.SetTrigger("Attack");
            StopCoroutine("MoveTo");
        }
    }

    IEnumerator MoveTo()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, ClosestEnemy().transform.position, movementSpeed * Time.deltaTime);
			anim.SetTrigger("Speed");
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
            other.gameObject.SendMessage("TakeDamage", 38);
        }
    }
}
