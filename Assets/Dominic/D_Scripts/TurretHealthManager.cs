using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretHealthManager : MonoBehaviour
{
    public Slider healthBarSlider;
	GameObject friendlyTurret;
	BaseLifeBehaviour baseLife;
	
    void Start()
    {	
		friendlyTurret = GameObject.Find("Base");
		baseLife = friendlyTurret.GetComponent<BaseLifeBehaviour>();
    }

    void Update()
    {
		healthBarSlider.value = baseLife.health;
    }
}
