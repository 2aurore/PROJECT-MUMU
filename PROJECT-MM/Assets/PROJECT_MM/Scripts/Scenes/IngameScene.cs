using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameScene : SceneBase
{
    public override IEnumerator OnStart()
    {
        // Ingame ���� �񵿱�� �ε��Ѵ�.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Ingame", LoadSceneMode.Single);

        // �ε尡 �Ϸ� �� �� ���� yield return null �� �ϸ鼭 ��ٸ���.
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
