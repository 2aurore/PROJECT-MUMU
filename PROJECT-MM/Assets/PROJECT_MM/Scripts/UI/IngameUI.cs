using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : UIBase
{
    public static IngameUI Instance => UIManager.Singleton.GetUI<IngameUI>(UIList.IngameUI);

    // public void Awake() {
    //     if (Instance == null) 
    //     {
    //         Instance = this;  
    //     } 
    //     else {
    //         Destroy(gameObject);
    //     }
    // }

    // private void OnDestroy() {
    //     if (Instance == this)
    //     {
    //         Instance = null;
    //     }
    // }

    public Image hpBar;
    public Image spBar;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI spText;

    public void SetHP(float current, float max) 
    {
        hpBar.fillAmount = current / max;
        hpText.text = $"{current:0} / {max: 0}";
    }

    public void SetSP(float current, float max) 
    {
        spBar.fillAmount = current / max;
        spText.text = $"{current:0} / {max: 0}";
    }
}
