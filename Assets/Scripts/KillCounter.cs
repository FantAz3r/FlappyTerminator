using System;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    public int _kills { get; private set; }

    public event Action ValueChange;

    private void OnEnable()
    {
        _spawner.Died += Count;
    }

    private void OnDisable()
    {
        _spawner.Died -= Count;
    }

    public void Count()
    {
        _kills++;
        ValueChange?.Invoke();
    }

    public void Reset()
    {
        _kills = 0;
        ValueChange?.Invoke();
    }
}
