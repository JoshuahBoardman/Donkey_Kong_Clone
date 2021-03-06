using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public Vector2 speedOfBarrel;
    
    public float barreltSpeed = 2;

    public bool moveRight;

    private int earlyExitChance;

    private bool wallsDisabled;

    private Rigidbody2D rigidbody;
    private Detection myDetection;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        myDetection = GetComponent<Detection>();
    }
    
    void Start()
    {
        InvokeRepeating("EarlyExitChance", 0f, 1f);
    }

    private void FixedUpdate()
    {
        speedOfBarrel = rigidbody.velocity;
        DirectionChange();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(earlyExitChance % 3 == 0)
        {
            Physics2D.IgnoreLayerCollision(11, 7, true);
            wallsDisabled = true;
        }
        else
        {
            Physics2D.IgnoreLayerCollision(11, 7, false);
            wallsDisabled = false;
        }
    }

    public void SpawnMovement()
    {
        moveRight = true;
        rigidbody.velocity = transform.right * 2 ; //new Vector2(rigidbody.velocity.x + barreltSpeed, rigidbody.velocity.y) * Time.deltaTime;
    }
    private void DirectionChange()
    {     
        if (myDetection.isWall && !wallsDisabled)
        {
            if (moveRight)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                rigidbody.velocity = new Vector2(-barreltSpeed, rigidbody.velocity.y) * Time.deltaTime;
                moveRight = false;
            }
            else if (!moveRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rigidbody.velocity = new Vector2(barreltSpeed, rigidbody.velocity.y) * Time.deltaTime;
                moveRight = true;
            }
        }
    }

    private void EarlyExitChance()
    {
        earlyExitChance = Random.Range(1, 10);
    }

    public void SetMoveRight()
    {
        moveRight = true;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void SetMoveLeft()
    {
        moveRight = false;
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

}
