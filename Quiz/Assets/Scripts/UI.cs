using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text textTarget;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject panelLoad;
    [SerializeField]
    private Constructor grid;
    [SerializeField]
    private Transform childLoad;

    private Effect effect;
    private float widthPanelLoad;

    private void Start()
    {
        effect.FadeMaterialA(textTarget);
        widthPanelLoad = panelLoad.GetComponent<RectTransform>().rect.width;
    }

    public void CompleteTarget(string str)
    {
        textTarget.text = "Find " + str;
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        button.SetActive(true);
        effect.FadeImageA(panel, 0.5f);
    }

    public void CloseButtonReload()
    {
        button.SetActive(false);
        OpenPanelLoad();
    }

    private void OpenPanelLoad()
    {
        panelLoad.SetActive(true);
        effect.FadeImageA(panelLoad,1);
        effect.Load(childLoad, 0);
        Invoke("ClosePanelLoad", 2f);
        grid.ReloadConstruct();
    }

    private void ClosePanelLoad()
    {
        childLoad.localPosition = new Vector3(-widthPanelLoad, 0, 0);
        panelLoad.SetActive(false);
        panel.SetActive(false);
    }
}
