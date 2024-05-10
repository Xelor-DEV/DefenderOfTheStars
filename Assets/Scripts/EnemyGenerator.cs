using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject kamikazeEnemy;
    [SerializeField] private GameObject boss;
    [Header("Enemy Generation Intervals")]
    [SerializeField] private float basicEnemySpawnRate;
    [SerializeField] private float kamikazeEnemySpawnRate;
    [SerializeField] private float bossSpawnRate;
    [SerializeField] private GameObject player;
    void Start()
    {
        basicEnemy.GetComponent<BasicEnemy>().playerTransform = player.transform;
        kamikazeEnemy.GetComponent<KamikazeEnemy>().playerTransform = player.transform;

        StartCoroutine(SpawnBasicEnemy());
        StartCoroutine(SpawnKamikazeEnemy());
        //StartCoroutine(SpawnBoss());
    }

    IEnumerator SpawnBasicEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(basicEnemySpawnRate);
            Vector2 spawnPosition = new Vector2(9.8f, Random.Range(-4.11f, 4.11f));
            Instantiate(basicEnemy, spawnPosition, Quaternion.identity);
        }
    }

    IEnumerator SpawnKamikazeEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(kamikazeEnemySpawnRate);
            Vector2 spawnPosition = new Vector2(9.8f, Random.Range(-4.11f, 4.11f));
            Instantiate(kamikazeEnemy, spawnPosition, Quaternion.identity);
        }
    }

    IEnumerator SpawnBoss()
    {
        while (true)
        {
            yield return new WaitForSeconds(bossSpawnRate);
            Vector2 spawnPosition = new Vector2(9.8f, Random.Range(-4.11f, 4.11f));
            Instantiate(boss, spawnPosition, Quaternion.identity);
        }
    }
}
