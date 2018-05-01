using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    Animator anim;
    private float horizontal;
    private float distance = 0.5f;
    private int speed = 2;
    public float delay = 5f;
    public bool die;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        {
            if (Physics.Raycast(transform.position, transform.right, distance))
            {

            }

            float move = horizontal;
            anim.SetFloat("Speed", move);
        }
    }

    void Movement()
    {
        {
            if (this.transform.position.x > 0)
            {
                transform.Translate(Vector2.right * 2f * Time.deltaTime);
                anim.Play("Bomb");
                //Destroy (gameObject, delay);
            }
            else if (this.transform.position.x < 0)
            {
                transform.Translate(-Vector2.right * 2f * Time.deltaTime);
                anim.Play("BombRobotLeft");
            }
        }
    }
}