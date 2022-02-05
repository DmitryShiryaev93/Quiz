using UnityEngine;
using System;

[Serializable]
public class CellData
{
    [SerializeField]
    private string _target;

    [SerializeField]
    private Sprite _sprite;

    public string Target => _target;
    public Sprite Sprite => _sprite;
}
