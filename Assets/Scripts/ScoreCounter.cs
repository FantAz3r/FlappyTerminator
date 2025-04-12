using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreCharged;

    public void Add()
    {
        _score++;
        ScoreCharged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreCharged?.Invoke(_score);
    }
}
