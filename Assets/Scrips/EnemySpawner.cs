using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float firstSpawnDelay = 5;
    [SerializeField] float secondsBetweenSpawns = 5f;

    [SerializeField] Transform enemy;
    [SerializeField] Transform enemyParentTransform;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true) //forever
        {
            yield return new WaitForSeconds(firstSpawnDelay);
            Instantiate(enemy, enemyParentTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
            //newEnemy.transform.parent = enemyParentTransform;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "FireBarrel")
        {
            Destroy(collision.gameObject);
            Instantiate(enemy, enemyParentTransform.position, Quaternion.identity);
        }
    }
}
