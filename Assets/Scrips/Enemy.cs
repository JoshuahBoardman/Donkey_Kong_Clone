using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float turnRate = 5f;

    private float originalSpeed;

    private int climbChance;
    private int turnChance;
    

    private bool moveRight;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private Detection myDetection;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        myDetection = GetComponent<Detection>();
        originalSpeed = speed;
    }
    void Start()
    {
        InvokeRepeating("TurnChance", 0f, turnRate);
        InvokeRepeating("ClimbChance", 0f, 1f);
    }

    private void Update()
    {
        EnemyCollision();
    }

    private void FixedUpdate()
    {
        LedgeAndWallProtection();
        Patrol();
        RunTowardsPlayer();
        ClimbLadder();
    }

    private void Patrol()
    {
        if (myDetection.isGrounded)
        {
            if (turnChance % 2f == 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y) * Time.deltaTime;
                moveRight = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y) * Time.deltaTime;
                moveRight = false;
            }
        }
    }

    private void ClimbLadder()
    {

        if (myDetection.isLadder && !myDetection.isPlayer)
        {
            if(climbChance == 4 || climbChance == 8)
            {
                rigidbody.velocity = new Vector2(0,  climbSpeed) * Time.deltaTime;
                boxCollider.isTrigger = true;
            }
            else
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0) * Time.deltaTime;
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
        if (myDetection.isPlayer)
        {
            speed += (speed* .8f) * Time.deltaTime;
        }
        else 
        {
            speed = originalSpeed;
        }
    }

    private void LedgeAndWallProtection() // pervents enemy from running of the ledge or running into a wall.
    {
        if (myDetection.isLedge == true && !myDetection.isLadder || myDetection.isWall && !myDetection.isLadder)
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
}
