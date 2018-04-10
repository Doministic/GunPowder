using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretType turret;
    public int health;
    public int damage;
    public int fireRate;
    public int rotationAmount;
    public bool turretSelected;
    // Use this for initialization
    void Start()
    {
        health = turret.turretHealth;
        damage = turret.turretDamage;
        fireRate = turret.turretFireRate;
        rotationAmount = turret.turretRotationAmount;

        Instantiate(turret.TurretPrefab,transform.position,Quaternion.identity).transform.parent = gameObject.transform;
    }
    public void TurretSelection()
    {
        turretSelected = !turretSelected;
    }
}
