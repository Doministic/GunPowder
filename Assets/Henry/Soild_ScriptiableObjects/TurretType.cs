using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TurretName" , menuName = "Turret")]
public class TurretType : ScriptableObject
{
    public string turretType;
	public GameObject TurretPrefab;
	
	[Range(0,100)]
	public int turretHealth;
	public int turretDamage;
	[Range(0,1)]
	public float turretFireRate;
	public bool updateFireRate;
	public int turretRotationAmount;
}
