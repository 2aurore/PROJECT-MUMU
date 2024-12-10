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

    }

    public override IEnumerator OnEnd()
    {
        yield return null;

        UIManager.Hide<IngameUI>(UIList.IngameUI);
    }
}
