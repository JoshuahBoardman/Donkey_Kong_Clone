using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{

    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheckR;
    [SerializeField] Transform groundCheckL;
    [SerializeField] Transform ladderCheck;
    [SerializeField] Transform ladderCheckB;
    [SerializeField] Transform triggerCheck;

    [SerializeField] float movementSpeed = 5;
    [SerializeField] float jumpPower = 5;
    [SerializeField] float climbingSpeed = 3;

    public bool isGrounded;
    public bool isLadder;

    private bool isTrigger;

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxColider;
    

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxColider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        GrounDetection();
        LadderDetection();
        TriggerDetection();
        HorizontalMovement();
        Jump();
        ClimbLadder();
        DescendLadder();
    }

    private void HorizontalMovement()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            myRigidbody.velocity = new Vector2(movementSpeed, myRigidbody.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
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
            myRigidbody.velocity = new Vector2(0, climbingSpeed);
            myRigidbody.gravityScale = 0;
        }                                                    
        else
        {
            myRigidbody.gravityScale = 1;
        }
    }

    private void DescendLadder()
    {
        if (Input.GetKey("s") && isLadder && isTrigger || Input.GetKey("down") && isLadder && isTrigger)
        {
            myBoxColider.isTrigger = true;
            myRigidbody.velocity = new Vector2(0, -climbingSpeed);
            myRigidbody.gravityScale = 0;
        }
        else
        {
            myBoxColider.isTrigger = false;
            myRigidbody.gravityScale = 1;
        }
    }

    private void GrounDetection()
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
        if (Physics2D.Linecast(transform.position, ladderCheck.position, 1 << LayerMask.NameToLayer("Ladder")) ||
            Physics2D.Linecast(transform.position, ladderCheckB.position, 1 << LayerMask.NameToLayer("Ladder")))
        {
            isLadder = true;
        }
        else
        {
            isLadder = false;
        }
    }

    private void TriggerDetection()
    {
        if (Physics2D.Linecast(transform.position, triggerCheck.position, 1 << LayerMask.NameToLayer("Trigger")))
        {
            isTrigger = true;
        }
        else
        {
            isTrigger = false;
        }
    }
}
