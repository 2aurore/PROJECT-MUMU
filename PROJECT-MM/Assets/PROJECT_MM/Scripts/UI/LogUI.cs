using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class LogList
{
    public string[] logs;
}

public class LogUI : UIBase
{

    public static LogUI Instance => UIManager.Singleton.GetUI<LogUI>(UIList.LogUI);

    public GameObject logPrefab;
    public Transform logContent;
    public ScrollRect scrollRect;

    private LogList logList;
    private int currentLogIndex = 0;



    private void OnGUI()
    {
        GUI.skin.box.wordWrap = true;
    }


    void AddChatMessage(string message)
    {
        // 대화 프리팹을 인스턴스화
        GameObject newChat = Instantiate(logPrefab, logContent);

        // 대화 프리팹의 Text 컴포넌트를 설정
        Text chatText = newChat.GetComponent<Text>();
        chatText.text = message;

        // 스크롤을 가장 아래로 고정
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }

}
