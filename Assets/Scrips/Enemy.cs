using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float climbSpeed = 5;

    private float randomNumber;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void Randomness()
    {
        randomNumber = Random.Range(1f, 10f);
    }
}
