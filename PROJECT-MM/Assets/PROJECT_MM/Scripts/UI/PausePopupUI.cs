using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PausePopupUI : UIBase
{
    // 게임 일시정지 버튼 메소드
    public void OnClickResumeButton()
    {
        Time.timeScale = 1f;
        UIManager.Hide<PausePopupUI>(UIList.PausePopupUI);
    }


    // 게임 종료 버튼 메소드
    public void OnClickExitButton()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;    // 엔진에서 게임을 종료 처리하도록 함
    }

    // 타이틀 UI로 돌아가기 버튼
    public void OnClickBackButton()
    {
        UIManager.Hide<PausePopupUI>(UIList.PausePopupUI);

        Time.timeScale = 1f;
        Main.Instance.ChangeScene(SceneType.Title);
    }
}
