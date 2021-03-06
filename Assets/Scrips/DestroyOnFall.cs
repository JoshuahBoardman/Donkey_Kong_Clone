using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{

    private PlayerAttributes attributes;

    private void Awake()
    {
        attributes = GetComponent<PlayerAttributes>();
    }

    void Update()
    {
        DealWithFallingObjects();
    }

    private void DealWithFallingObjects()
    {
        if (transform.position.y <= -10 && this.gameObject.layer == 3)
        {
            ResetPlayer();
        }
        else if (transform.position.y <= -10 && this.gameObject.layer == 7)
        {
            Destroy(this.gameObject);
        }
    }

    private void ResetPlayer()
    {
        attributes.health--;
        this.gameObject.transform.position = new Vector2(-7.425f, 0.518f);
    }
}
