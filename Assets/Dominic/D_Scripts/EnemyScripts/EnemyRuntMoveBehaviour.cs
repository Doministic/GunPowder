using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRuntMoveBehaviour : MonoBehaviour
{

    public float movementSpeed = 2.5f;
    public float stoppingDistance = 0.9f;
    public float timeTillDestroy = 5.0f;
    public Gradient colorGrad;

    ResourceManager resourceManager;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool attack;
    private int speed;
    private float blinkTime = 2;
    private int grainLevel;
    private bool grainDestroy = false;
    private int scrapLevel;
    private const int maxGrain = 200;
    private const int maxScrap = 300;

    void Start()
    {
        grainLevel = maxGrain;
        scrapLevel = maxScrap;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        StartCoroutine("MoveTo");
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, ClosestEnemy().transform.position);
        float t = Mathf.PingPong(Time.time / blinkTime, 1);
        Debug.Log("The Gran Level is: " + grainLevel);
        Debug.Log("The Scrap Level is: " + scrapLevel);
        if (grainDestroy)
        {
            InvokeRepeating("ConsumeGrain", 1.0f, 20.0f);
        }
        if (grainLevel <= 0)
        {
            grainLevel = 0;
            CancelInvoke("ConsumeGrain");
            Die();
        }
        if (distanceToTarget <= stoppingDistance)
        {
            StopCoroutine("MoveTo");
            spriteRenderer.color = colorGrad.Evaluate(t);
            anim.SetTrigger("Attack");
        }
    }

    private void OnBecameVisible()
    {
        grainDestroy = true;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Base")
        {
			Debug.Log("Hit");
            other.gameObject.SendMessage("TakeDamage", 40);
        }
        if (other.gameObject.tag == "regFriendlyBullet")
        {
            scrapLevel -= 25;
            if (scrapLevel == 0)
            {
                Die();
            }
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

    void ConsumeGrain()
    {
        grainLevel = grainLevel - 1;
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


    public void Die()
    {
        transform.position = new Vector2(1000, 1000);
        Destroy(gameObject, timeTillDestroy);
    }
}
