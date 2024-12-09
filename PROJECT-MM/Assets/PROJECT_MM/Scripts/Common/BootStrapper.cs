using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper
{
#if UNITY_EDITOR
    private static readonly List<string> AutoBootStrapperScenes = new List<string>()
    {
        // TODO : 자동으로 시스템이 초기화 되어서 실행 될 수 있는 씬 이름들을 추가.

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
        // TODO : 게임에 필요한 필수 시스템 초기화
        UIManager.Singleton.Initialize();

        // 인게임 실행에 필요한 UI나 추가 작업이 있다면 여기서 추가할 것.
        UIManager.Show<IngameUI>(UIList.IngameUI);
    }
}
