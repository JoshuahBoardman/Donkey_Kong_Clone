using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5;
    [SerializeField] float jumpPower = 5;
    [SerializeField] float climbingSpeed = 3;

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxColider;
    private Detection myDetection;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxColider = GetComponent<BoxCollider2D>();
        myDetection = GetComponent<Detection>();
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
        Jump();
        ClimbLadder();
        DescendLadder();
    }

    private void HorizontalMovement()
    {
        if (myDetection.isGrounded)
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                myRigidbody.velocity = new Vector2(movementSpeed, myRigidbody.velocity.y) * Time.deltaTime;
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                myRigidbody.velocity = new Vector2(-movementSpeed, myRigidbody.velocity.y) * Time.deltaTime;
            }
            else
            {
                myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y) * Time.deltaTime;
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKey("space") && myDetection.isGrounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpPower) * Time.deltaTime;
        }
    }

    private void ClimbLadder()
    {

        if (Input.GetKey("w") && myDetection.isLadder || Input.GetKey("up") && myDetection.isLadder)
        {
            myRigidbody.velocity = new Vector2(0, climbingSpeed) * Time.deltaTime;
            myRigidbody.gravityScale = 0;
        }                                                    
        else
        {
            myRigidbody.gravityScale = 1;
        }
    }

    private void DescendLadder()
    {
        if (Input.GetKey("s") && myDetection.isTrigger && myDetection.isLadder ||
            Input.GetKey("down") && myDetection.isTrigger && myDetection.isLadder)
        {
            myBoxColider.isTrigger = true;
            myRigidbody.velocity = new Vector2(0, -climbingSpeed) * Time.deltaTime;
            myRigidbody.gravityScale = 0;
        }
        else
        {
            myBoxColider.isTrigger = false;
            myRigidbody.gravityScale = 1;
        }
    }
}
