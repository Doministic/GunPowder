using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretType turret;
    public bool rotary, wideshot, cannon, precision;
    TotalCost refTotalCost;
    public bool turretSelected;

    [SerializeField]
    private int currentHealth;
    private float turretFireRate;
    // Use this for initialization
    void Start()
    {
        refTotalCost = FindObjectOfType<TotalCost>();
        DontDestroyOnLoad(gameObject);
        currentHealth = turret.turretHealth;
        Instantiate(turret.TurretPrefab, transform.position, Quaternion.identity).transform.parent = gameObject.transform;
    }
    public void TurretSelection()
    {
        turretSelected = !turretSelected;
    }
    public void RefundTurret()
    {
        if (rotary == true)
        {
            refTotalCost.updateMachineGunCost(-35,-45);
            Destroy(gameObject);
        }
        if (wideshot == true)
        {
            refTotalCost.updateWideShotCost(-60,-20);

        }
        if (cannon == true)
        {
            refTotalCost.updateCannonCost(-25,-55);

        }
        if (precision == true)
        {
            refTotalCost.updateSniperCost(-50,-30);

        }
    }
}
