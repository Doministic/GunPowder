using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    public Image Bar;
    public float Cur_HP = 0f;
    public float Max_HP = 200f;

	void Start ()
    {
        Cur_HP = Max_HP;
        //InvokeRepeating("DrainGrain" , 0f, .0667f);
	}
	
	//void DrainGrain ()
    //{
        //Cur_HP -= 1f;
        //float calc_health = Cur_HP / Max_HP;
        //SetHealth(calc_health);
        //if (Cur_HP <= 0)
            //Die();
	//}

    void SetHealth(float myhealth)
    {
        Bar.fillAmount = myhealth;
    }

    void Die()
    {
        Cur_HP = 0;
        Debug.Log("Dead");
    }

}
