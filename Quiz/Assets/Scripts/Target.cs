using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Target
{
    private string _target;
    public string TargetSt => _target;

    private List<string> listUsingTargets = new List<string>();
    private List<Cell> listCell;
    public UI UI { get; set; }

    public void FindTarget(List<string> listTargets)
    {
        int rndValueForSelectTarget = Random.Range(0, listTargets.Count);
        
        if (listUsingTargets.Count == 0)
        {
            AddTargetStringInlistUsingTargets(listTargets, rndValueForSelectTarget);
        }
        else
        {
            for (int j = 0; j < listUsingTargets.Count; j++)
            {
                if (listUsingTargets[j] == listTargets[rndValueForSelectTarget])
                {
                    rndValueForSelectTarget = Random.Range(0, listTargets.Count);
                    j = -1;
                }
            }
            AddTargetStringInlistUsingTargets(listTargets, rndValueForSelectTarget);
        }
    }

    private void AddTargetStringInlistUsingTargets(List<string> listTargets, int rndValueForSelectTarget)
    {
        string bufTarget = listTargets[rndValueForSelectTarget];
        listUsingTargets.Add(bufTarget);
        _target = bufTarget;
        UI.CompleteTarget(_target);
        SendAMessage();
    }

    public void AddCell(List<Cell> cell, List<string> listTargets)
    {
        listCell = cell;
        FindTarget(listTargets);
    }

    private void SendAMessage()
    {
        foreach(Cell i in listCell)
        {
            i.SetAGoal(_target);
        }
    }
}
