using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float turnRate = 5f;

    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ladderCheck;
    [SerializeField] private Transform ladderCheckB;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform playerCheck;

    private int climbChance;
    private int turnChance;

    private bool isPlayer;
    private bool isLedge;
    private bool isLadder;
    private bool isWall;
    private bool isGrounded;
    private bool moveRight;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        InvokeRepeating("TurnChance", 0f, turnRate);
        InvokeRepeating("ClimbChance", 0f, 1f);
    }

    private void FixedUpdate()
    {
        GroundDetection();
        LedgeDetection();
        LadderDetection();
        WallDetection();
        PlayerDetection();
        EnemyCollision();
        LedgeAndWallProtection();
        Patrol();
        RunTowardsPlayer();
        ClimbLadder();
    }

    private void Patrol()
    {
        if (isGrounded)
        {
            if (turnChance % 2f == 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
                moveRight = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
                moveRight = false;
            }
        }
    }

    private void ClimbLadder()
    {

        if (isLadder)
        {
            if(climbChance % 4 == 0)
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

    private void RunTowardsPlayer()
    {
        if (isPlayer)
        {
            speed = 5f;
        }
        else
        {
            speed = 2f;
        }
    }

    private void LedgeAndWallProtection() // pervents enemy from running of the ledge or running into a wall.
    {
        if (isLedge == true && !isLadder || isWall && !isLadder)
        {
            if (moveRight == false)
            {
                turnChance = 2;
            }
            if (moveRight == true)
            {
                turnChance = 3;
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

    private void EnemyCollision()
    {
        Physics2D.IgnoreLayerCollision(7, 7, true);
    }

    private void PlayerDetection()
    {
        if (Physics2D.Linecast(transform.position, playerCheck.position, 1 << LayerMask.NameToLayer("Player")))
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
    }

    private void LedgeDetection()
    {
        if (Physics2D.Linecast(transform.position, ledgeCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isLedge = false;
        }
        else
        {
            isLedge = true;
        }
    }

    private void WallDetection()
    {
        if (Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer("Wall")))
        {
            isWall = true;
        }
        else
        {
            isWall = false;
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
