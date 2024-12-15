using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameScence : SceneBase
{

    public override IEnumerator OnStart()
    {
        // Ingame 씬을 비동기로 로드한다.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Ingame", LoadSceneMode.Single);

        // 로드가 완료될 때 까지 yield return null 을 하면서 기다린다
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        UIManager.Show<IngameUI>(UIList.IngameUI);
        MM.InputSystem.Singleton.OnEscapeInput += OnEscapeExecute;

    }

    public override IEnumerator OnEnd()
    {
        yield return null;

        MM.InputSystem.Singleton.OnEscapeInput -= OnEscapeExecute;
        UIManager.Hide<IngameUI>(UIList.IngameUI);
    }

    void OnEscapeExecute()
    {
        Time.timeScale = 0f;
        UIManager.Show<PausePopupUI>(UIList.PausePopupUI);
    }

}
