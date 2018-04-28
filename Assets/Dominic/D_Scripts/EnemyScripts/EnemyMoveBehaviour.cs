using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBehaviour : MonoBehaviour
{
    public AudioClip[] clips;

    public float movementSpeed = 5.0f;
    public float stoppingDistance = 5.0f;
    public float shootingDistance = 8.0f;
    public float timeTillDestroy = 5;
    public Gradient colorGrad;

    // private Color colorChange;
    private SpriteRenderer spriteRender;
    private float blinkTime = 2;
    private int health;
    private int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
        StartCoroutine("MoveTo");
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        if (transform.position.x > 1)
        {
            transform.rotation = new Quaternion(0, 0, -0.4f, 0.9f);
        }
        else if (transform.position.x < -1)
        {
            transform.rotation = new Quaternion(0, 0, 0.4f, 0.9f);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0.9f);
        }
    }

    IEnumerator MoveTo()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, ClosestEnemy().transform.position, movementSpeed * Time.deltaTime);
            yield return null;
        }
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, ClosestEnemy().transform.position);
        float t = Mathf.PingPong(Time.time / blinkTime, 1);

        if (distanceToTarget <= stoppingDistance)
        {
            StopCoroutine("MoveTo");
            spriteRender.color = colorGrad.Evaluate(t);
            Die();
        }
        if (distanceToTarget <= shootingDistance)
        {
            GetComponentInChildren<EnemyBulletBehavior>().enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "regFriendlyBullet")
        {
            health -= 25;
            if (health <= 0)
            {
                Die();
            }
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
    
    void Die()
    {
        // int clipPick = Random.Range(0, clips.Length);
        // GetComponent<AudioSource>().clip = clips[clipPick];
        // GetComponent<AudioSource>().Play();
        // gameObject.GetComponent<Collider2D>.enabled = !enabled;
        //transform.position = new Vector2(1000, 1000);
        Destroy(gameObject, timeTillDestroy);
    }
}
