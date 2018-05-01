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

        if (rotary == true && turretSelected == true)
        {
            refTotalCost.updateMachineGunCost(-35, -45);
            DrawRayAndSendMessage();

            Destroy(gameObject);
        }
        if (wideshot == true && turretSelected == true)
        {
            refTotalCost.updateWideShotCost(-60, -20);
            DrawRayAndSendMessage();

            Destroy(gameObject);
        }
        if (cannon == true && turretSelected == true)
        {
            refTotalCost.updateCannonCost(-25, -55);
            DrawRayAndSendMessage();

            Destroy(gameObject);
        }
        if (precision == true && turretSelected == true)
        {
            refTotalCost.updateSniperCost(-50, -30);
            DrawRayAndSendMessage();

            Destroy(gameObject);
        }
    }
    public void DrawRayAndSendMessage()
    {
        RaycastHit hitinfo;
        if (Physics.Raycast(transform.position, Vector3.forward, out hitinfo, 2))
        {
            print(hitinfo.collider.name);
            hitinfo.collider.SendMessage("TileIsOpen");
        }
    }
}
