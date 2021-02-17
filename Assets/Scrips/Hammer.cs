using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] private float hammerBuffDuration = 10f;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
    }

    public void HammerBuffDuration()
    {
        if (gameObject.activeSelf == true)
        {
            Invoke("DisableHammer", hammerBuffDuration);
        }
    }

    private void DisableHammer()
    {
        gameObject.SetActive(false);
    }
}
