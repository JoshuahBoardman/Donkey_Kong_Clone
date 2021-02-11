using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float turnRate = 5f;

    [SerializeField] private Transform ledgeCheckR;
    [SerializeField] private Transform ledgeCheckL;
    [SerializeField] private Transform ladderCheck;
    [SerializeField] private Transform ladderCheckB;
    [SerializeField] private Transform groundCheck;

    private int climbChance;
    private int turnChance;

    private bool isLedge;
    private bool isLadder;
    [SerializeField] private bool isGrounded;
    private bool moveRight;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        InvokeRepeating("TurnChance", 0f, turnRate);
        InvokeRepeating("ClimbChance", 0f, 1f);
        InvokeRepeating("Patrol", 0f, 1f);
    }

    private void FixedUpdate()
    {
        GroundDetection();
        LedgeDetection();
        LadderDetection();

        LedgeSave();
        ClimbLadder();
    }

    private void Patrol()
    {
        if (isGrounded)
        {
            if (turnChance % 2f == 0)
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
    }

    private void ClimbLadder()
    {

        if (isLadder)
        {
            if(climbChance % 4 == 0 || isGrounded == false)
            {
                rigidbody.velocity = new Vector2(0,  climbSpeed);
                boxCollider.isTrigger = true;
            }
            else
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
                boxCollider.isTrigger = false;
                rigidbody.gravityScale = 0;
            }
        }
        else
        {
            boxCollider.isTrigger = false;
            rigidbody.gravityScale = 1;
        }
    }

    private void LedgeSave() // pervents enemy from running of the ledge.
    {
        if (isLedge == true && !isLadder)
        {
            if (moveRight == false)
            {
                rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            }
            if (moveRight == true)
            {
                rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            }
        }

    }

    private void TurnChance()
    {
        turnChance = Random.Range(1, 10);
    }

    private void ClimbChance()
    {
        climbChance = Random.Range(1, 10);
    }

    private void LedgeDetection()
    {
        if (Physics2D.Linecast(transform.position, ledgeCheckR.position, 1 << LayerMask.NameToLayer("Ground")) && 
            Physics2D.Linecast(transform.position, ledgeCheckL.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isLedge = false;
        }
        else
        {
            isLedge = true;
        }
    }

    private void LadderDetection()
    {
        if (Physics2D.Linecast(transform.position, ladderCheck.position, 1 << LayerMask.NameToLayer("BrokenLadder")) ||
           Physics2D.Linecast(transform.position, ladderCheck.position, 1 << LayerMask.NameToLayer("Ladder")) ||
           Physics2D.Linecast(transform.position, ladderCheckB.position, 1 << LayerMask.NameToLayer("BrokenLadder"))||
           Physics2D.Linecast(transform.position, ladderCheckB.position, 1 << LayerMask.NameToLayer("Ladder")))
        {
            isLadder = true;
        }
        else
        {
            isLadder = false;
        }
    }

    private void GroundDetection()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }
}
