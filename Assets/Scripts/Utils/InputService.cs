using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    [SerializeField] private KeyCode JumpKey = KeyCode.Space;
    [SerializeField] private KeyCode AbilityKey = KeyCode.E;

    public event Action Jumped;
    public event Action Attacked;

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
        {
            Jumped?.Invoke();
        }

        if (Input.GetKeyDown(AbilityKey))
        {
            Attacked?.Invoke();
        }
    }
}
