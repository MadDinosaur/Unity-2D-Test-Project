using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    private float movement = 0f;
    private Animator playerAnimation;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();

    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(movement * speed, jumpSpeed);
        }
        else
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }

        //Animation
        playerAnimation.SetFloat("Speed", Math.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("isTouchingGround", isTouchingGround);
        if (movement >= 0f)
        {
            transform.localScale = new Vector2(-Math.Abs(rigidBody.transform.localScale.x), rigidBody.transform.localScale.y);
        } else
        {
            transform.localScale = new Vector2(Math.Abs(rigidBody.transform.localScale.x), rigidBody.transform.localScale.y);
        }
    }
}