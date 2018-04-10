using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBehaviour : MonoBehaviour
{
    public AudioClip[] clips;

    public Transform objectToMoveTo;
    public float maxMovementSpeed = 7.5f;
    public float minMovementSpeed = 3.5f;
    public float stoppingDistance = 5.0f;
    public float shootingDistance = 8.0f;
    public float timeTillDestroy = 5;
    public Gradient colorGrad;

    // private Color colorChange;
    private SpriteRenderer spriteRender;
    private float blinkTime = 2;
    private float step = 0.0f;
    private int health;
    private int maxHealth = 100;
    private int minHealth = 0;

    void Start()
    {
        health = maxHealth;
        step = Random.Range(minMovementSpeed, maxMovementSpeed);
        StartCoroutine(MoveTo(step));
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        if (transform.position.x >= 0)
            {
                //angle = Mathf.Atan2(vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
                //q = Quaternion.AngleAxis(angle, Vector3.forward * 0.25f);
                transform.rotation = new Quaternion(0,0,-0.4f,0.9f);
            }
            else
            {
                //angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                //q = Quaternion.AngleAxis(angle, Vector3.forward  * -1f);
                transform.rotation = new Quaternion(0,0,0.4f,0.9f);
            }
    }

    IEnumerator MoveTo(float step)
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, ClosestEnemy().transform.position, step * Time.deltaTime);
            //transform.LookAt(transform.position + new Vector3(0,0,0.5f), ClosestEnemy().transform.position);
            //Vector3 vectorToTarget = ClosestEnemy().transform.position - transform.position;
            //float angle;
            //Quaternion q;

            // if (transform.position.x > 0)
            // {
            //     //angle = Mathf.Atan2(vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
            //     //q = Quaternion.AngleAxis(angle, Vector3.forward * 0.25f);
            //     transform.rotation = new Quaternion(0,0,-45,0);
            // }
            // else
            // {
            //     //angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            //     //q = Quaternion.AngleAxis(angle, Vector3.forward  * -1f);
            //     transform.rotation = new Quaternion(0,0,45,0);
            // }
            //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);
            yield return null;
        }
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, ClosestEnemy().transform.position);
        float t = Mathf.PingPong(Time.time / blinkTime, 1);

        //transform.rotation = new Quaternion(0,0,90,0);
        Debug.Log(transform.rotation);

        if (distanceToTarget <= stoppingDistance)
        {
            StopAllCoroutines();
            Destroy(gameObject, timeTillDestroy);
            spriteRender.color = colorGrad.Evaluate(t);
        }
        if (distanceToTarget <= shootingDistance)
        {
            GetComponentInChildren<EnemyBulletBehavior>().enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Base")
        {
            Debug.LogWarning("Entered Base");
            Die();
        }
        else if (other.gameObject.tag == "regFriendlyBullet")
        {
            health -= 25;
            if (health <= minHealth)
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
        int clipPick = Random.Range(0, clips.Length);
        GetComponent<AudioSource>().clip = clips[clipPick];
        GetComponent<AudioSource>().Play();
        //gameObject.GetComponent<Collider2D>.enabled = !enabled;
        transform.position = new Vector2(1000, 1000);
        Destroy(gameObject, .5f);
    }
}
