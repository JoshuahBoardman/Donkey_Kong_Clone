using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    
    [SerializeField] private float barreltSpeed = 2;

    private bool moveRight;

    private Rigidbody2D rigidbody;
    private Detection myDetection;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        myDetection = GetComponent<Detection>();
    }
    void Start()
    {
        SpawnMovement();
    }

    private void FixedUpdate()
    {
        DirectionChange();
    }

    private void SpawnMovement()
    {
        moveRight = true;
        rigidbody.velocity = new Vector2(barreltSpeed, rigidbody.velocity.y);
    }
    private void DirectionChange()
    {     
        if (myDetection.isWall)
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
}
