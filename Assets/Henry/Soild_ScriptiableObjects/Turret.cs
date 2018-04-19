using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretType turret;
    public bool turretSelected;

    [SerializeField]
    private int currentHealth;
    private float turretFireRate;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentHealth = turret.turretHealth;
        Instantiate(turret.TurretPrefab, transform.position, Quaternion.identity).transform.parent = gameObject.transform;
    }
    public void TurretSelection()
    {
        turretSelected = !turretSelected;
    }
}
