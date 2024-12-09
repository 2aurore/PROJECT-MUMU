using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper
{
#if UNITY_EDITOR
    private static readonly List<string> AutoBootStrapperScenes = new List<string>()
    {
        // TODO : �ڵ����� �ý����� �ʱ�ȭ �Ǿ ���� �� �� �ִ� �� �̸����� �߰�.

        "Ingame",
    };

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void SystemBoot()
    {
        var activeScene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
        for (int i = 0; i < AutoBootStrapperScenes.Count; i++)
        {
            if (activeScene.name.Equals(AutoBootStrapperScenes[i]))
            {
                InternalBoot();
                break;
            }
        }
#endif
    }

    private static void InternalBoot()
    {
        // TODO : ���ӿ� �ʿ��� �ʼ� �ý��� �ʱ�ȭ
        UIManager.Singleton.Initialize();

        // �ΰ��� ���࿡ �ʿ��� UI�� �߰� �۾��� �ִٸ� ���⼭ �߰��� ��.
        UIManager.Show<IngameUI>(UIList.IngameUI);
    }
}
