using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] float speed;
    private Rigidbody2D rigidbody2D;
    private Vector3 change;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxis("Horizontal");
        MoveCharacter();
    }

    void MoveCharacter()
    {
        rigidbody2D.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
