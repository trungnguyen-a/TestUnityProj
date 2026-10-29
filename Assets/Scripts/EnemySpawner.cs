using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform[] patrolPoints;

    public void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Count());
        GameObject enemy = Instantiate(enemyPrefab[randomEnemy], transform.position, Quaternion.identity);

        if (enemy.TryGetComponent<EnemyAI>(out var enemyAI))
        {
            enemyAI.SetPatrolPoint(patrolPoints[0], patrolPoints[1]);
        }
    }
}
