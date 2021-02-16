using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{

    [SerializeField] Barrel barrel;
    [SerializeField] Transform barrelParentTransform;

    [SerializeField] int minSpawnRate = 4;
    [SerializeField] int maxSpawnRate = 7;

    private float secondsBetweenSpawns;

    void Start()
    {
        InvokeRepeating("SpawnChance", 0f, 1f);
        StartCoroutine(SpawnBarrels());
    }

    IEnumerator SpawnBarrels()
    {
        while (true) //forever
        {
            var newBarrel = Instantiate(barrel, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
            newBarrel.transform.parent = barrelParentTransform;
        }
    }

    private void SpawnChance()
    {
        secondsBetweenSpawns = Random.Range(minSpawnRate, maxSpawnRate);
    }
}
