using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _enemyOffset = 2f;
    [SerializeField] private int _enemyInWawe;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private Coroutine _spawnCoroutine;

    public void StartSpawn()
    {
        _spawnCoroutine = StartCoroutine(Generate());
    }

    public void StopSpawn()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        RemoveEntities();
    }

    private IEnumerator Generate()
    {
        while (enabled)
        {
            Spawn();
            yield return _delay;
        }
    }

    private void Spawn()
    {
        int skipIndex = Random.Range(0, _enemyInWawe);

        for (int i = 0; i < _enemyInWawe; i++)
        {
            if (skipIndex != i)
            {
                float xPosition = 0;
                float yOffset = i * _enemyOffset;
                Vector2 spawnPoint = new Vector2(xPosition, transform.position.y + yOffset);

                Enemy enemy = SpawnEntity(spawnPoint);
                enemy.LaunchingAnEntity(Vector2.left);
                enemy.Construct(_bulletSpawner);
            }
        }
    }
}
