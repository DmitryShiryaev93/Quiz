using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Developer : MonoBehaviour
{
    [SerializeField]
    private UI ui;
    [SerializeField]
    private CellBundleData[] typesCellData;
    [SerializeField]
    private LevelData[] typesLevelData;
    [SerializeField]
    private GameObject prefabCell;
    [SerializeField]
    private Transform canvas;
    [SerializeField]
    private Constructor constructor; // один из возможных типов размещения ячеек 

    private void Start()
    {
        constructor.ConstructAScene(ui, typesCellData, typesLevelData, prefabCell, canvas);
    }
}
