using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private PlayerAttributes attributes;

    private void Awake()
    {
        attributes = GetComponent<PlayerAttributes>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = attributes.health;
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
            attributes.health--;
            if (health <= 1)
            {
                GameOver();
            }
        }
    }

    private void GameOver() 
    {
        SceneManager.LoadScene(0);
    }
}
