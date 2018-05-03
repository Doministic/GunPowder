using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombMoveBehaviour : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float stoppingDistance = 0.5f;
    public AudioClip[] clips;

    ResourceManager resourceManager;
    private int grainLevel;
    private int scrapLevel;
    private const int maxGrain = 5;
    private const int maxScrap = 200;
    
    void Start()
    {
        grainLevel = maxGrain;
        scrapLevel = maxScrap;
        resourceManager = FindObjectOfType<ResourceManager>();
        StartCoroutine("MoveTo");
    }

    private void Update()
    {
        if(grainLevel <= 0 || scrapLevel <= 0){
            Die();
        }
    }

    private void OnBecameVisible()
    {
        StartCoroutine("GrainConsume");
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Base")
        {
            other.gameObject.SendMessage("TakeDamage", 17);
            Die();
        }
        if (other.gameObject.tag == "regFriendlyBullet")
        {
            int clipPick = Random.Range(0, clips.Length);
            GetComponent<AudioSource>().clip = clips[clipPick];
            GetComponent<AudioSource>().Play();
            scrapLevel -= 60;
        }
        else if(other.gameObject.tag == "Shotgun Bullet"){
            scrapLevel -= 75;
        }
        else if(other.gameObject.tag == "CannonBullet"){
            scrapLevel -= 85;
        }
        else if(other.gameObject.tag == "SniperBullet"){
            scrapLevel -= 150;
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

    IEnumerator GrainConsume(){
        while(true){
            grainLevel--;
            yield return new WaitForSeconds(1.25f);
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
        transform.position = new Vector2(1000, 1000);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        resourceManager.GrainManager(grainLevel);
        resourceManager.ScrapManager(scrapLevel);
    }

}
