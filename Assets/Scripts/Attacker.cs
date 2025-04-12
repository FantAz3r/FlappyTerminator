using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;

    public void Attack(Health target)
    {
        target.TakeDamage(_damage);
    }
}
