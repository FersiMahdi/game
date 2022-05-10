using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public byte movespeed;
    public byte jumpforce;
    private bool isJumping = false;
    public byte jmpLim;
    public int jmpNum;
    
    public bool isOnGround;
    public bool canFly;
    public bool canFlip;
    public Transform GroundCheckLeft;
    public Transform GroundCheckRight;
    public Rigidbody2D rb;
    public Vector3 velocity = Vector3.zero;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        
    }

    void Update()
    {
        isOnGround = Physics2D.OverlapArea(GroundCheckLeft.position, GroundCheckRight.position);
        if (isOnGround) jmpNum=0;


        float horizontalMovement = Input.GetAxis("Horizontal") * movespeed;//* Time.deltaTime

        if (Input.GetButtonDown("Jump") && (isOnGround || canFly))
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }
    void MovePlayer(float horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            
            rb.AddForce(new Vector2(0f, jumpforce/(1+(jmpNum*jmpLim))));
            isJumping = false;
            jmpNum++;

        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f && canFlip)
        {
            spriteRenderer.flipX = true;
        }
    }
}
