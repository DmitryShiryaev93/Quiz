using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Constructor : MonoBehaviour
{
    public abstract void ConstructAScene(UI ui, CellBundleData[] typesCellData, LevelData[] typesLevelData, GameObject prefabCell, Transform canvas);
    public abstract void BlockAllCell();
    public abstract void OpenAllCell();
    public abstract void DeleteConstruct();
    public abstract void ReloadConstruct();

}
