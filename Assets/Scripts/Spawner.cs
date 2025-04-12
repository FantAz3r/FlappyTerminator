using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : BaseEntity
{
    [SerializeField] private T _prefab;
    [SerializeField] private float _spawnRate;

    private ObjectPool<T> _pool;
    protected WaitForSeconds _delay;
    
    protected virtual void Awake()
    {
        _delay = new WaitForSeconds(_spawnRate);
        _pool = new ObjectPool<T>(_prefab);
    }

    private void OnEnable()
    {
        _pool.Released += OnReleased;
    }

    protected virtual T SpawnEntity(Vector2 position)
    {
        T entity = _pool.Get();
        entity.transform.position = position;
        entity.Deactivate += DeactivateEntity;
        return entity;
    }

    protected virtual void DeactivateEntity(BaseEntity entity)
    {
        _pool.Release((T)entity);
    }

    protected void RemoveEntities()
    {
        _pool.Clear();
    }

    private void OnReleased(BaseEntity entity)
    {
        entity.Deactivate -= DeactivateEntity;
    }
}
