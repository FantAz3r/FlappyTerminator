using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    public Bullet GetBullet(Vector2 position)
    {
        return SpawnEntity(position);
    }

    public void RemoveBullets()
    {
        RemoveEntities();
    }
}
