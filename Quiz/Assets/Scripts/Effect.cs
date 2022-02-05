using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public struct Effect
{
    public void FadeMaterialA(Text mat)
    {
        mat.DOFade(1f, 1);
    }

    public void FadeImageA(GameObject mat, float value)
    {
        mat.GetComponent<Image>().DOFade(value, 1);
    }

    public void PunchPos(Transform go)
    {
        go.DOPunchPosition(new Vector3(3,0,0), 1);
    }

    public void PunchScale(Transform go)
    {
        go.DOPunchScale(new Vector3(0.4f, 0.4f, 0), 1);
    }

    public void Load(Transform go, float to)
    {
        go.DOMoveX(to, 2);
    }
}
