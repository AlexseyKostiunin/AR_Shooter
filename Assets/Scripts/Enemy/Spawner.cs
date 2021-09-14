using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Player _target;

    private void Start()
    {
        StartCoroutine(SpawnRandomEnemy());
    }

    private IEnumerator SpawnRandomEnemy()
    {
        while (true)
        {
            Enemy newEnemy = Instantiate(_enemies[Random.Range(0, _enemies.Length)],
                GetRandomPlaceInSphere(_spawnRadius), Quaternion.identity);

            LookMe(newEnemy);

            newEnemy.Dying += OnEnemyDying;

            yield return new WaitForSeconds(_secondsBetweenSpawn);
        }
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _target.AddScore();
    }

    private Vector3 GetRandomPlaceInSphere(float radius)
    {
        return Random.insideUnitSphere * radius;
    }

    private void LookMe(Enemy enemy)
    {
        Vector3 lookDirection = _target.transform.position - enemy.transform.position;
        enemy.transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
