using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;
    [SerializeField] float jumpPower = 5;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheckR;
    [SerializeField] Transform groundCheckL;

    private bool isGrounded; 
    private Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))||
            Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            myRigidbody.velocity = new Vector2(movementSpeed, myRigidbody.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            myRigidbody.velocity = new Vector2(-movementSpeed, myRigidbody.velocity.y);
        }
        else
        {
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpPower);
        }
    }
}
