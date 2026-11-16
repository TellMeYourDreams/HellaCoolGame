using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private float EnemyInterval = 2f;

    private float spawnHealthBonus;

    private void Start()
    {
        StartCoroutine(spawnEnemy(EnemyInterval, EnemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);

        spawnHealthBonus += 10f;
        newEnemy.GetComponent<Enemy>().AddSpawnHealth(spawnHealthBonus);

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}