using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PausePopupUI : UIBase
{
    public void OnClickResumeButton()
    {
        UIManager.Hide<PausePopupUI>(UIList.PausePopupUI);
    }
}
