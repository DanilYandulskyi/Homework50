using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private ScoreUI _ui;

    public static event Action AddScore;

    private void Start()
    {
        _ui.UpdateText(_count.ToString());
    }

    public void Add()
    {
        ++_count;

        _ui.UpdateText(_count.ToString());
    }
}
