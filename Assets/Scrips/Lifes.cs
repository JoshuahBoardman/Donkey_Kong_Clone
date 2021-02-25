using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    [SerializeField] GameObject lifeOne;
    [SerializeField] GameObject lifeTwo;
    [SerializeField] GameObject lifeThree;
    [SerializeField] PlayerAttributes attributes;

    private void Awake()
    {
        PlayerAttributes attributes = GetComponent<PlayerAttributes>();
    }

    private void Update()
    {
        LifeSprites();
    }

    private void LifeSprites()
    {
        var health = attributes.health;
        if (health == 2)
        {
            lifeOne.SetActive(false);
        }
        else if (health == 1)
        {
            lifeTwo.SetActive(false);
        }
        else if (health == 0)
        {
            lifeThree.SetActive(false);
        }
        else
        {
            lifeOne.SetActive(true);
            lifeTwo.SetActive(true);
            lifeThree.SetActive(true);
        }
    }

}
