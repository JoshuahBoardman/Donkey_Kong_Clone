using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOnJump : MonoBehaviour
{
    [SerializeField] int pointsAwarded = 100;

    [SerializeField] Score score;
    [SerializeField] Detection characterDetection;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            if (characterDetection.isGrounded == false && characterDetection.isLadder == false)
            {
                score.AddPoints(pointsAwarded);
            }
        }
    }
}
