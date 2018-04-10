using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRobot : MonoBehaviour {
    Animator Anim;
	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        float move = Input.GetAxis("Horizontal");
        Anim.SetFloat("Speed", move);

    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector2.right * 3f * Time.deltaTime);
        }
    }
}
