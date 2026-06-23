using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;


public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [Tooltip("Час респавну в секундах")]
    public float respawnTime = 300f; 

    private GameObject currentEnemy;

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        if (currentEnemy == null)
        {
            StartCoroutine(RespawnEnemy());
            enabled = false;
        }
    }

    IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(respawnTime);

        SpawnEnemy();

        enabled = true;
    }

    void SpawnEnemy()
    {
        currentEnemy = Instantiate(
            enemyPrefab,
            transform.position,
            transform.rotation
        );
    }
}
