using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRuntMoveBehaviour : MonoBehaviour
{

    public float movementSpeed = 2.5f;
    public float stoppingDistance = 0.9f;
    public float timeTillDestroy = 5.0f;
    public Gradient colorGrad;
    public AudioClip[] clips;

    ResourceManager resourceManager;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool attack;
    private int speed;
    private float blinkTime = 2;
    private int grainLevel = 0;
    private int scrapLevel = 0;
    private const int maxGrain = 200;
    private const int maxScrap = 300;

    void Start()
    {
        grainLevel = maxGrain;
        scrapLevel = maxScrap;
        spriteRenderer = GetComponent<SpriteRenderer>();
        resourceManager = FindObjectOfType<ResourceManager>();
        anim = GetComponent<Animator>();
        if (transform.position.x > 0)
        {
            transform.rotation = new Quaternion(0, 0.9f, 0, 0);
        }
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, ClosestEnemy().transform.position);
        float t = Mathf.PingPong(Time.time / blinkTime, 1);
        if (grainLevel <= 0 || scrapLevel <= 0)
        {
            Die();
        }
        if (distanceToTarget <= stoppingDistance)
        {
            StopCoroutine("MoveTo");
            spriteRenderer.color = colorGrad.Evaluate(t);
            anim.SetTrigger("Attack");
        }
        else
        {
            StartCoroutine("MoveTo");
        }
    }

    private void OnBecameVisible()
    {
        StartCoroutine("ConsumeGrain");
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
            int clipPick = Random.Range(0, clips.Length);
            GetComponent<AudioSource>().clip = clips[clipPick];
            GetComponent<AudioSource>().Play();
            scrapLevel -= 50;
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
            grainLevel--;
            yield return new WaitForSeconds(0.1f);
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

    public void Die()
    {
        transform.position = new Vector2(1000, 1000);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        resourceManager.GrainManager(grainLevel);
        resourceManager.ScrapManager(scrapLevel);
    }
}
