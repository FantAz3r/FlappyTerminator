using UnityEngine;

[RequireComponent(typeof(Attacker))]

public class Bullet : BaseEntity
{
    private GameObject _owner;
    private Attacker _attacker;

    protected override void Awake()
    {
        base.Awake();
        _attacker = GetComponent<Attacker>();
    }

    public void Initialize(GameObject owner)
    {
        _owner = owner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _owner)
        {
            return; 
        }
        else if(collision.TryGetComponent(out Health health))
        {
            _attacker.Attack(health);
        }

        if (collision.TryGetComponent<Despawner>(out _))
        {
            Despawn();
        }
    }
}
