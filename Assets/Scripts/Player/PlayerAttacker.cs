using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;

    private float _startAngleZ;

    private void Awake()
    {
        _startAngleZ = transform.eulerAngles.z;
    }

    public void Shoot()
    {
        float angle = (transform.eulerAngles.z - _startAngleZ) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)); 

        Bullet bullet = _bulletSpawner.GetBullet(transform.position);
        bullet.LaunchingAnEntity(direction.normalized);
        bullet.Initialize(this.gameObject);
    }
}
