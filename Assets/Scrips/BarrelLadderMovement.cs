using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelLadderMovement : MonoBehaviour
{

    private int descendLadderChance;

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
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x + (myBarrel.barreltSpeed * .75f), myRigidbody.velocity.y) * Time.deltaTime;
            }
            else
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x + (-myBarrel.barreltSpeed * .75f), myRigidbody.velocity.y) * Time.deltaTime;
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
                this.gameObject.tag = "Enemy";
                myCollider.isTrigger = true;
                myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y) * Time.deltaTime;
                myBarrel.SetMoveLeft();
            }
            else if (descendLadderChance == 6 && myBarrel.moveRight == false ||
                     descendLadderChance == 3 && myBarrel.moveRight == false)
            {
                this.gameObject.tag = "Enemy";
                myCollider.isTrigger = true;
                myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y) * Time.deltaTime;
                myBarrel.SetMoveRight();
            }
        }
        else
        {
            this.gameObject.tag = "Untagged";
            myCollider.isTrigger = false;
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y);
        }

    }

    private void DescendLadderChance()
    {
        descendLadderChance = Random.Range(1, 10);
    }
}
