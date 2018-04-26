using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    Animator Anim;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Movement () {
        transform.Translate(Vector2.right * 2f * Time.deltaTime);
        float move = Input.GetAxis("Horizontal");
        Anim.SetFloat("Speed", move);;

    }
    void Update()
    {
        Movement();
    }
}
