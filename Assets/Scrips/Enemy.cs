using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float turnRate = 5f;

    [SerializeField] private Transform groundCheckR;
    [SerializeField] private Transform groundCheckL;

    private int randomNumber;

    private bool isGrounded;
    private bool moveRight;

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("Patrol", 0f, turnRate);
    }

    private void FixedUpdate()
    {
        GrounDetection();
        LedgeSave();
    }

    void Patrol()
    {
        randomNumber = Random.Range(1, 10);
        Debug.Log(randomNumber);

        if (randomNumber % 2f == 0)
        {
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            moveRight = true;
        }
        else
        {
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            moveRight = false;
        }

    }
    private void LedgeSave()
    {
        if (!isGrounded)
        {
            if(moveRight == false)
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            else
            {
                rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            }
        
        }
    }

    private void GrounDetection()
    {
        if (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")) && 
            Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
