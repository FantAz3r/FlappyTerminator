
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetY;
    [SerializeField] private PlayerMover _player;

    private void LateUpdate()
    {
        var position = transform.position;
        position.x = _player.transform.position.x + _offsetX;
        position.y = _player.transform.position.y + _offsetY;
        transform.position = position;
    }
}
