using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator animator;

    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        
        Debug.Log(movement.x + " " + movement.y);

        if (movement.y == 1)
        {
            animator.SetInteger("Direccion", 3);
        }
        else if(movement.y == -1)
        {
            animator.SetInteger("Direccion", 1);
        }

        else if (movement.x == 1)
        {
            animator.SetInteger("Direccion", 2);
        }
        else if (movement.x == -1)
        {
            animator.SetInteger("Direccion", 4);
        }

    }

    void FixedUpdate()
    {

        if (Math.Abs(movement.x) == Math.Abs(movement.y))
        {
            rb.MovePosition(rb.position + movement * (moveSpeed/1.5f) * Time.fixedDeltaTime);
        }
        else {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }    

        
    }
}
