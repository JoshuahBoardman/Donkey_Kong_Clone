using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{

    [SerializeField] Barrel barrel;
    [SerializeField] Barrel fireBarrel;
    [SerializeField] Barrel ladderBarrel;
    [SerializeField] Transform barrelParentTransform;

    [SerializeField] int minSpawnRate = 2;
    [SerializeField] int maxSpawnRate = 7;

    private int typeOfBarrelSpawnChance;

    private float secondsBetweenSpawns;

    private void Awake()
    {
        secondsBetweenSpawns = 4;
    }

    void Start()
    {
        InvokeRepeating("SpawnChance", 0f, 1f);
        InvokeRepeating("TypeOfBarrelSpawnChance", 0f, 1f);
        StartCoroutine(SpawnBarrels());
    }

    IEnumerator SpawnBarrels()
    {
        while (true) //forever
        {
            if(typeOfBarrelSpawnChance == 6 || typeOfBarrelSpawnChance == 8)
            {
                var newLadderBarrel = Instantiate(ladderBarrel, transform.position, Quaternion.identity);
                newLadderBarrel.transform.parent = barrelParentTransform;
                newLadderBarrel.SpawnMovement();
            }
            else if(typeOfBarrelSpawnChance == 9)
            {
                var newFireBarrel = Instantiate(fireBarrel, transform.position, Quaternion.identity);
                newFireBarrel.transform.parent = barrelParentTransform;
                newFireBarrel.SpawnMovement();
            }
            else
            {
                var newBarrel = Instantiate(barrel, transform.position, Quaternion.identity);
                newBarrel.transform.parent = barrelParentTransform;
                newBarrel.SpawnMovement();
            }
            yield return new WaitForSeconds(secondsBetweenSpawns);
            
        }
    }

    private void SpawnChance()
    {
        secondsBetweenSpawns = Random.Range(minSpawnRate, maxSpawnRate);
    }

    private void TypeOfBarrelSpawnChance()
    {
       typeOfBarrelSpawnChance = Random.Range(1, 10);
    }
}
