using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{

    public GameObject projectile;

    private int bulletCount = 50;
    private int minBullets = 0;

    private bool canShoot;
    private float timer = 0.0f;
    private float shotTimer = 0.5f;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shotTimer)
        {
            timer = timer - shotTimer;
            if (canShoot == true && bulletCount > minBullets)
            {
                SpawnBullet();
            }
        }
    }

    

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 2000.0f);
        bulletCount--;
    }

    public void CannotFire()
    {
        canShoot = false;
    }

    public void CanFire()
    {
        canShoot = true;
    }

}
