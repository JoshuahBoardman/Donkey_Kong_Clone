using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{

    [SerializeField] Barrel barrel;
    [SerializeField] Transform barrelParentTransform;
    [SerializeField] float secondsBetweenSpawns = 2;

    void Start()
    {
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
}
