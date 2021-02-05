using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;
    [SerializeField] float jumpPower = 5;
    [SerializeField] float cimbingSpeed = 3;

    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheckR;
    [SerializeField] Transform groundCheckL;

    [SerializeField] Transform ladderCheck;
    [SerializeField] Transform ladderCheckR;
    [SerializeField] Transform ladderCheckL;

    private bool isGrounded;
    private bool isLadder;
    private Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        GrounDetectiond();
        LadderDetection();
        HorizontalMovement();
        Jump();
        ClimbLadder();
    }

    private void GrounDetectiond()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
                    Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")) ||
                    Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void LadderDetection()
    {
        if (Physics2D.Linecast(transform.position, ladderCheck.position, 1 << LayerMask.NameToLayer("Ladder")))
        {
            isLadder = true;
        }
        else
        {
            isLadder = false;
        }
    }
    

    private void HorizontalMovement()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            myRigidbody.velocity = new Vector2(movementSpeed, myRigidbody.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            myRigidbody.velocity = new Vector2(-movementSpeed, myRigidbody.velocity.y);
        }
        else
        {
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetKey("space") && isGrounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpPower);
        }
    }
    private void ClimbLadder()
    {
        if (Input.GetKey("w") && isLadder || Input.GetKey("up") && isLadder)
        {
            myRigidbody.velocity = new Vector2(0, cimbingSpeed);
            myRigidbody.gravityScale = 0;
        }                                                    
        else
        {
            myRigidbody.gravityScale = 1;
        }
    }
}
