using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : UIBase
{
    public void OnClickStartButton()
    {
        Main.Instance?.ChangeScene(SceneType.Ingame);
    }

    public void OnClickExitButton()
    {
        Main.Instance?.SystemQuit();
    }
}
