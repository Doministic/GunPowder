using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    public GameObject projectile;

    private bool canShoot;
    private float timer = 0.0f;
    private float shotTimer = 0.30f;

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
            if (CanFire())
            {
                SpawnBullet();
            }
        }
    }

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 500.0f);
    }
    public bool CanFire()
    {
        return canShoot;
    }
    public void FlipCanFire()
    {
        canShoot = !canShoot;
    }
}
