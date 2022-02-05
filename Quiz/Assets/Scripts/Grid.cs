using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : Constructor
{
    private CellBundleData[] typesCellData;
    private LevelData[] typesLevelData;
    private GameObject prefabCell;
    private Transform canvas;
    private UI ui;

    private Vector3 originPosition;
    private float prefabWidth;
    private float parentWidth;
    private float parentHeight;

    private List<GameObject> listGOCell = new List<GameObject>();
    private List<Cell> listCell = new List<Cell>();
    private Target target = new Target();

    public override void ConstructAScene(UI _ui, CellBundleData[] _typesCellData, LevelData[] _typesLevelData, GameObject _prefabCell, Transform _canvas)
    {
        ui = _ui;
        typesCellData = _typesCellData;
        typesLevelData = _typesLevelData;
        prefabCell = _prefabCell;
        canvas = _canvas;

        prefabWidth = prefabCell.GetComponent<RectTransform>().rect.width;
        parentWidth = canvas.position.x;
        parentHeight = canvas.position.y;
        target.UI = ui;

        CreateGrid();
        PunchScaleAllCell();
    }

    int numberLevel = 0; // итерации от 0 до typesLevelData.Length-1;

    private void CreateGrid()
    {
        int columns = typesLevelData[numberLevel].Columns;
        int rows = typesLevelData[numberLevel].Row;

        float xOriginPosition = parentWidth - ((columns * prefabWidth / 2) - prefabWidth / 2);
        float yOriginPosition = parentHeight - ((rows * prefabWidth / 2) - prefabWidth / 2);
        originPosition = new Vector3(xOriginPosition, yOriginPosition);

        CellBundleData cellBundleData = typesCellData[Random.Range(0, typesCellData.Length)];

        List<CellData> listCellData = new List<CellData>(cellBundleData.Cells);
        List<string> listTargets = new List<string>();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                CellData cellData = listCellData[Random.Range(0, listCellData.Count)];

                MassageForCells(CreateCell(j, i), cellData); // инфо ячейкам
                
                listTargets.Add(cellData.Target); // таргету информацию об используемых строчках
                listCellData.Remove(cellData);
            }
        }
        target.AddCell(listCell, listTargets); // таргету информацию о используемых ячейках
    }

    private void MassageForCells(GameObject cell, CellData cellData)
    {
        Cell bufCell = cell.GetComponent<Cell>();
        bufCell.FixSprite(cellData.Sprite, cellData.Target); // ячейке спрайт и строчку
        bufCell.constructor = this;
        listCell.Add(bufCell);
    }

    private GameObject CreateCell(int j, int i)
    {
        GameObject cell = Instantiate(prefabCell);
        Vector3 posCell = new Vector3(j, i) * prefabWidth + originPosition;
        cell.transform.SetParent(canvas);
        cell.transform.localPosition = posCell;
        cell.transform.localScale = Vector3.one;
        listGOCell.Add(cell);
        return cell;
    }

    public override void DeleteConstruct()
    {
        if (numberLevel == typesLevelData.Length - 1)
        {
            ui.OpenPanel();
            numberLevel = 0;
            return;
        }
        else
        {
            numberLevel++;
            DestroyListGOCell();
            EmptyListCell();
            CreateGrid();
        }
    }

    public override void ReloadConstruct()
    {
        numberLevel = 0;
        DestroyListGOCell();
        EmptyListCell();
        CreateGrid();
        PunchScaleAllCell();
    }

    private void PunchScaleAllCell()
    {
        Effect effect;
        foreach (GameObject i in listGOCell)
        {
            effect.PunchScale(i.transform);
        }
    }

    private void DestroyListGOCell()
    {
        foreach (GameObject i in listGOCell)
        {
            Destroy(i);
        }
        listGOCell.Clear();
    }

    public override void BlockAllCell()
    {
        foreach (Cell i in listCell)
        {
            i.OpenCloseCell = false;
        }
    }

    public override void OpenAllCell()
    {
        foreach (Cell i in listCell)
        {
            i.OpenCloseCell = true;
        }
    }

    public void EmptyListCell()
    {
        listCell.Clear();
    }
}

