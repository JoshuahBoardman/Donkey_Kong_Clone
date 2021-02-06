using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] float barreltSpeed = 2;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(barreltSpeed, rigidbody.velocity.y);
    }

 
}
