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

    ResourceManager resourceManager;
    private SpriteRenderer spriteRender;
    private float blinkTime = 2;
    private int grainLevel;
    private int scrapLevel;
    private const int maxGrain = 550;
    private const int maxScrap = 450;

    void Start()
    {
        grainLevel = maxGrain;
        scrapLevel = maxScrap;
        resourceManager = FindObjectOfType<ResourceManager>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        if (transform.position.x > 1.5f)
        {
            transform.rotation = new Quaternion(0, 0, -0.4f, 0.9f);
        }
        else if (transform.position.x < 1.5f)
        {
            transform.rotation = new Quaternion(0, 0, 0.4f, 0.9f);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0.9f);
        }
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, ClosestEnemy().transform.position);
        float t = Mathf.PingPong(Time.time / blinkTime, 1);

        if (distanceToTarget <= stoppingDistance)
        {
            StopCoroutine("MoveTo");
            Destroy(gameObject, timeTillDestroy);
            spriteRender.color = colorGrad.Evaluate(t);
        }
        else
        {
            StartCoroutine("MoveTo");
        }
        if (distanceToTarget <= shootingDistance)
        {
            GetComponentInChildren<EnemyBulletBehavior>().enabled = true;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "regFriendlyBullet")
        {
            scrapLevel -= 25;
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
            yield return new WaitForSeconds(0.35f);
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
        int clipPick = Random.Range(0, clips.Length);
        GetComponent<AudioSource>().clip = clips[clipPick];
        GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        resourceManager.GrainManager(grainLevel);
        resourceManager.ScrapManager(scrapLevel);
    }
}
