using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefab;

    public void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Count());
        Instantiate(enemyPrefab[randomEnemy], transform.position, Quaternion.identity);
    }
}
