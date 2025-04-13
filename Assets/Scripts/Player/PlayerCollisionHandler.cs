using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<IObstacle> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IObstacle interacteble))
        {
            CollisionDetected?.Invoke(interacteble);
        }
    }
}
