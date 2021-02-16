using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPickUp : MonoBehaviour
{
    [SerializeField] private Transform hammerHitbox;

    [SerializeField] bool isPlayer = false;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {

            Destroy(gameObject);
        }
    }


}
