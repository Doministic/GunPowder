using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveandAttackAnim : MonoBehaviour {
    Animator anim;
    private bool attack;
    private bool facingRight;
    private float horizontal;
    private float distance = 0.5f;
    private int speed = 2;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
        HandleAttack();
        Movement();
        if (Physics.Raycast(transform.position, transform.right, distance))
        {
            Debug.Log("HIT!");
            anim.SetTrigger("Attack");
        }

        {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);
    }
}

void Movement()
{
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 2f * Time.deltaTime);
        }
     if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector2.right * 2f * Time.deltaTime);
        }
    }

    private void HandleAttack()
    {
        if (attack)
        {
            anim.SetTrigger("Attack");
        }
    }
    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            attack = true;
            Debug.Log("True");
        }
        else
        {
            attack = false;
        }
    }
}
