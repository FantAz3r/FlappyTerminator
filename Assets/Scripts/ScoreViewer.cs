using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private KillCounter _killCounter;

    private void OnEnable()
    {
        _killCounter.ValueChange += View;
    }

    private void OnDisable()
    {
        _killCounter.ValueChange -= View;
    }

    private void View()
    {
        _text.text = _killCounter._kills.ToString();
    }
}
