using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TurretName" , menuName = "Turret")]
public class TurretType : ScriptableObject
{
    public string turretType;
	public GameObject TurretPrefab;
	public int turretHealth;
	public int turretDamage;
	public int turretFireRate;
	public int turretRotationAmount;
}
