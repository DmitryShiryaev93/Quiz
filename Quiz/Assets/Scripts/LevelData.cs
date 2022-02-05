using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 52)]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int _columns;

    [SerializeField]
    private int _row;

    public int Columns => _columns;
    public int Row => _row;
}
