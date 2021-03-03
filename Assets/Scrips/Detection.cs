using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    public bool isGrounded;
    public bool isLadder;
    public bool isWall;
    public bool isTrigger;
    public bool isLedge;
    public bool isPlayer;

    // NOTE: If you dont have need of the below feilds, use the objects base transform.
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ladderCheck;
    [SerializeField] private Transform ladderCheckB;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform triggerCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;

    void Update()
    {
        GroundDetection();
        LadderDetection();
        WallDetection();
        Triggerdetection();
        LedgeDetection();
        PlayerDetection();
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

    private void LadderDetection()
    {
        if (Physics2D.Linecast(transform.position, ladderCheck.position, 1 << LayerMask.NameToLayer("Ladder")) ||
            Physics2D.Linecast(transform.position, ladderCheckB.position, 1 << LayerMask.NameToLayer("Ladder")))
        {
            isLadder = true;
        }
        else
        {
            isLadder = false;
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

    private void Triggerdetection()
    {
        if (Physics2D.Linecast(transform.position, triggerCheck.position, 1 << LayerMask.NameToLayer("Trigger")))
        {
            isTrigger = true;
        }
        else
        {
            isTrigger = false;
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
}
