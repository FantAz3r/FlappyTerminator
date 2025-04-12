using UnityEngine;

public class Flyer : MonoBehaviour
{
    [SerializeField] private float _speed; 

    public void Fly(float directionX, float directionY, Rigidbody2D rigidbody)
    {
        rigidbody.velocity = new Vector2( directionX * _speed, directionY * _speed) ;
    }
}
