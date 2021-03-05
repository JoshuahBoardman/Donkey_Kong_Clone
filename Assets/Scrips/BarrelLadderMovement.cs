using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelLadderMovement : MonoBehaviour
{

    private int descendLadderChance;
    private int secondsBetweenDescending = 5;

    private bool dropDownLadder;

    private Rigidbody2D myRigidbody;
    private CircleCollider2D myCollider;
    private Detection myDetection;
    private Barrel myBarrel;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CircleCollider2D>();
        myDetection = GetComponent<Detection>();
        myBarrel = GetComponent<Barrel>();
    }
    private void Start()
    {
        InvokeRepeating("DescendLadderChance", 0f, 1f);
    }

    private void FixedUpdate()
    {
        DescendLadder();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && myCollider.isTrigger == false ||
            collision.gameObject.layer == 10 && myCollider.isTrigger == false)
        {
            if (myBarrel.moveRight )
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x + (myBarrel.barreltSpeed/2), myRigidbody.velocity.y);
            }
            else
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x + (-myBarrel.barreltSpeed/2), myRigidbody.velocity.y);
            }
        }
    }

    private void DescendLadder()
    {
        if (myDetection.isTrigger || myDetection.isbrokenLadderTrigger)
        {
            if (descendLadderChance == 7 && myBarrel.moveRight ||
                descendLadderChance == 4 && myBarrel.moveRight)
            {
                myCollider.isTrigger = true;
                myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
                myBarrel.SetMoveLeft();
            }
            else if (descendLadderChance == 6 && myBarrel.moveRight == false ||
                descendLadderChance == 3 && myBarrel.moveRight == false)
            {
                myCollider.isTrigger = true;
                myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
                myBarrel.SetMoveRight();
            }
        }
        else
        {
            myCollider.isTrigger = false;
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y);
        }

    }

    private void DescendLadderChance()
    {
        descendLadderChance = Random.Range(1, 10);
    }
}
