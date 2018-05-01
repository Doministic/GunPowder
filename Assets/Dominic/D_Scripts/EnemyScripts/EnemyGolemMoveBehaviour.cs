using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGolemMoveBehaviour : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public float stoppingDistance = 1.3f;
    public Gradient colorGrad;

    ResourceManager resourceManager;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool attack;
    private bool speed;
    private float blinkTime = 2;
    private int grainLevel;
    private int scrapLevel;
    private const int maxGrain = 1000;
    private const int maxScrap = 1000;

    void Start()
    {
        grainLevel = maxGrain;
        scrapLevel = maxScrap;
        spriteRenderer = GetComponent<SpriteRenderer>();
        resourceManager = FindObjectOfType<ResourceManager>();
        animator = GetComponent<Animator>();
        StartCoroutine("MoveTo");
        if (transform.position.x > 0)
        {
            transform.rotation = new Quaternion(0, 0.9f, 0, 0);
        }
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, ClosestEnemy().transform.position);
        float t = Mathf.PingPong(Time.time / blinkTime, 1);
        if (distanceToTarget <= stoppingDistance)
        {
            StopCoroutine("MoveTo");
            spriteRenderer.color = colorGrad.Evaluate(t);
            animator.SetTrigger("Attack");
        }
        if (grainLevel <= 0 || scrapLevel <= 0)
        {
            Die();
        }

    }

    private void OnBecameVisible()
    {
        StartCoroutine("ConsumeGrain");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Base")
        {
            other.gameObject.SendMessage("TakeDamage", 65);
        }

        if (other.gameObject.tag == "regFriendlyBullet")
        {
            scrapLevel -= 75;
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

    IEnumerator ConsumeGrain()
    {
        while (true)
        {
            --grainLevel;
            yield return new WaitForSeconds(0.01f);
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

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        resourceManager.GrainManager(grainLevel);
        resourceManager.ScrapManager(scrapLevel);
    }
}
