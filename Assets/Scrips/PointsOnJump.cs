using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOnJump : MonoBehaviour
{
    [SerializeField] int pointsAwarded = 100;

    [SerializeField] Score score;
    [SerializeField] CharacterControler character;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            if (character.isGrounded == false)
            {
                score.AddPoints(pointsAwarded);
            }
        }
    }
}
