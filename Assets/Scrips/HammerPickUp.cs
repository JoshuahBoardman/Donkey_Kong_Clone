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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isPlayer = true;
            Destroy(other);
        }
    }
}
