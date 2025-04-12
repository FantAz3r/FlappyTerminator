using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseEntity : MonoBehaviour
{
    private Flyer _flyer;
    protected Rigidbody2D _rigidbody;

    public event Action<BaseEntity> Deactivate;

    protected virtual void Awake()
    {
        _flyer = GetComponent<Flyer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void LaunchingAnEntity(Vector2 direction)
    {
        _flyer.Fly(direction.x, direction.y, _rigidbody); 
    }

    protected void Despawn()
    {
        Deactivate?.Invoke(this);
    }
}

