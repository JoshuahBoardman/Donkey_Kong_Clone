using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPickUp : MonoBehaviour
{
    [SerializeField] private GameObject hammerHitbox;
    [SerializeField] private Hammer hammer;


    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            hammerHitbox.SetActive(true);
            hammer.HammerBuffDuration();
            Destroy(gameObject);
        }
    }


}
