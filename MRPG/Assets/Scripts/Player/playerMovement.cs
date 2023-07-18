using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public string startpoint;

    Vector2 movement;

    public Animator animator;

    static bool playExists;

    private void Start()
    {
        loadPlayer();
        
    }

    void loadPlayer()
    {
        if (!playExists)
        {
            playExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        

    }

    private void FixedUpdate()
    {
        if(Math.Abs(movement.x) == Math.Abs(movement.y))
        {
            rb.MovePosition(rb.position + movement * (moveSpeed/1.5f) * Time.fixedDeltaTime);
        }
        else {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }    
        
    }
}
