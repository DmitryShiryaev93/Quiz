using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Transform childSprite;

    private string nameButton;
    private string targetStr;

    public Constructor constructor { get; set; }
    public bool OpenCloseCell { get; set; } = true;

    private new ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    private void OnMouseDown()
    {
        if (OpenCloseCell)
        {
            Effect effect;
            if (targetStr == nameButton)
            {
                effect.PunchScale(childSprite);
                particleSystem.Play();
                constructor.BlockAllCell();
                Invoke("CloseLevel", 5f);
            }
            else
            {
                effect.PunchPos(childSprite);
            }
        }
    }

    private void CloseLevel()
    {
        constructor.OpenAllCell();
        particleSystem.Stop();
        constructor.DeleteConstruct();
    }

    public void FixSprite(Sprite sprite, string _nameButton)
    {
        childSprite.GetComponent<Image>().sprite = sprite;
        nameButton = _nameButton;
    }

    public void SetAGoal(string _target)
    {
        targetStr = _target;
    }
}
