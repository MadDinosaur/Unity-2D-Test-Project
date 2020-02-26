using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement
    private Rigidbody2D rigidBody;
    public float speed;
    public float jumpSpeed;
    private float movement;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private bool isFacingRight = true;
    //Animation
    private Animator playerAnimation;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        transform.Rotate(0f, 180f, 0f);
    }

    void Update()
    {
        //Movement
        movement = Input.GetAxis("Horizontal");
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isTouchingGround)
            rigidBody.velocity = new Vector2(movement * speed, jumpSpeed);

        else
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);

        if (movement > 0f && !isFacingRight)
        {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }

        else if (movement < 0f && isFacingRight)
        {
            isFacingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }

        //Animation
        playerAnimation.SetFloat("Speed", Math.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("isTouchingGround", isTouchingGround);
        
    }
}