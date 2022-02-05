using UnityEngine;

[CreateAssetMenu(fileName = "New CellBundleData", menuName = "Cell Bundle Data", order = 51)]
public class CellBundleData : ScriptableObject
{
    [SerializeField]
    private CellData[] _cells;

    public CellData[] Cells => _cells;
}
