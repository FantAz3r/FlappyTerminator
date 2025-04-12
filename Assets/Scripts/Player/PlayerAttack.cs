using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;

    public void Shoot()
    {
        float angle = (transform.eulerAngles.z - 90) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)); 

        Bullet bullet = _bulletSpawner.GetBullet(transform.position);
        bullet.LaunchingAnEntity(direction.normalized);
        bullet.Initialize(this.gameObject);
    }
}
