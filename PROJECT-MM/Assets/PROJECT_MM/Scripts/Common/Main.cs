using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SceneType
{
    None,
    Empty,
    Title,
    Ingame,
}

public class Main : MonoBehaviour
{
    public static Main Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator Start()
    {
        Initialize();

        yield return null;

        ChangeScene(SceneType.Title);
    }

    public void Initialize()
    {
        // TODO : ���ӿ� �ʿ��� �ʼ� �ý��� �ʱ�ȭ
        UIManager.Singleton.Initialize();

    }

    bool isSceneChangeProgress = false;
    SceneBase currentSceneController = null;
    SceneType currentSceneType = SceneType.None;

    public void ChangeScene(SceneType sceneType, System.Action onSceneChangeCompletedCallback = null)
    {
        if (isSceneChangeProgress)
            return;

        if (currentSceneType == sceneType)
            return;

        currentSceneType = sceneType;
        switch (sceneType)
        {
            case SceneType.Title:
                StartCoroutine(ChangeScene<TitleScene>(onSceneChangeCompletedCallback));
                break;
            case SceneType.Ingame:
                StartCoroutine(ChangeScene<IngameScene>(onSceneChangeCompletedCallback));
                break;
        }
    }

    private IEnumerator ChangeScene<T>(System.Action onSceneChangeCompletedCallback = null) where T : SceneBase
    {
        UIManager.Show<LoadingUI>(UIList.LoadingUI);        
        isSceneChangeProgress = true;

        // ������ �ҷ��ξ��� �� ��Ʈ�ѷ�(Scene Base)�� �ִٸ�, OnEnd �� ȣ�� ���ְ� �����Ѵ�.
        if (currentSceneController != null)
        {
            yield return StartCoroutine(currentSceneController?.OnEnd());
            Destroy(currentSceneController.gameObject);
            currentSceneController = null;
        }

        // Empty ������ ��ȯ�� ���� �Ѵ�.
        AsyncOperation emptySceneLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Empty", UnityEngine.SceneManagement.LoadSceneMode.Single);
        while (!emptySceneLoad.isDone)
        {
            yield return null;
        }

        // ���ο� �� ��Ʈ�ѷ��� �����Ѵ�.
        GameObject newSceneController = new GameObject(typeof(T).Name);
        newSceneController.transform.SetParent(transform);
        currentSceneController = newSceneController.AddComponent<T>();
        yield return StartCoroutine(currentSceneController.OnStart());

        // �� ��ȯ�� �����ߴٰ� �÷��� ���� �����Ѵ�.
        isSceneChangeProgress = false;

        // �� ��ȯ �� - �ݹ� �Լ��� ȣ�����ش�.
        onSceneChangeCompletedCallback?.Invoke();
        UIManager.Hide<LoadingUI>(UIList.LoadingUI);
    }

    public void SystemQuit()
    {
        // TODO : ���� ���� �� ó���� �͵��� �߰��ϱ�
        

        // ���� ����.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
