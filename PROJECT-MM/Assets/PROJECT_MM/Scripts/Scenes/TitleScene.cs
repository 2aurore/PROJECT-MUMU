using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : SceneBase
{
    public override IEnumerator OnStart()
    {
        // Title ���� �񵿱�� �ε��Ѵ�.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Title", LoadSceneMode.Single);

        // �ε尡 �Ϸ� �� �� ���� yield return null �� �ϸ鼭 ��ٸ���.
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
