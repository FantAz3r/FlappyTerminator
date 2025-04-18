using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Attacker))]
public class Enemy : BaseEntity, IObstacle
{
    [SerializeField] private float _fireRate = 1f;

    private BulletSpawner _bulletSpawner;
    private WaitForSeconds _delay;
    private Coroutine _shootCoroutine; 
    private Health _health;

    public event Action<Enemy> Killed;

    protected override void Awake()
    {
        base.Awake();
        _delay = new WaitForSeconds(_fireRate);
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        Killed = null;
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Despawner>(out _))
        {
            if (_shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
                _shootCoroutine = null;
            }

            Despawn();
        }
    }

    public void Construct(BulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner;
        _shootCoroutine = StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while (enabled)
        {
            Shoot();
            yield return _delay;
        }
    }

    private void Shoot()
    {
        Vector2 bulletSpawnPosition = transform.position;
        Bullet bullet = _bulletSpawner.GetBullet(bulletSpawnPosition);
        bullet.Initialize(gameObject);
        bullet.LaunchingAnEntity(Vector2.left);
    }

    private void OnDied()
    {
        Killed?.Invoke(this);
        Despawn();
    }
}

