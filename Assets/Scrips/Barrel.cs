using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    
    [SerializeField] float barreltSpeed = 2;

    [SerializeField] private Transform wallCheck;

    private bool isWall;
    private bool moveRight;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        SpawnMovement();
    }

    private void Update()
    {
        WallDetection();
        DirectionChange();
    }

    private void SpawnMovement()
    {
        moveRight = true;
        rigidbody.velocity = new Vector2(barreltSpeed, rigidbody.velocity.y);
    }
    private void DirectionChange()
    {
        if (isWall)
        {
            if (moveRight)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                rigidbody.velocity = new Vector2(-barreltSpeed, rigidbody.velocity.y);
                moveRight = false;
            }
            else if (!moveRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rigidbody.velocity = new Vector2(barreltSpeed, rigidbody.velocity.y);
                moveRight = true;
            }
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


}
