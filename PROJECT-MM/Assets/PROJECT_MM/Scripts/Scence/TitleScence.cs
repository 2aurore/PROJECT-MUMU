using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScence : SceneBase
{
    public override IEnumerator OnStart()
    {
        // Title 씬을 비동기로 로드한다.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Title", LoadSceneMode.Single);

        // 로드가 완료될 때 까지 yield return null 을 하면서 기다린다
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        UIManager.Show<TitleUI>(UIList.TitleUI);
    }

    public override IEnumerator OnEnd()
    {
        yield return null;

        UIManager.Hide<TitleUI>(UIList.TitleUI);
    }
}
