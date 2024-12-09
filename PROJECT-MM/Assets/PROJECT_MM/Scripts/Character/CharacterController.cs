using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public CharacterBase linkedCharacter;

    private void Awake()
    {
        linkedCharacter = GetComponent<CharacterBase>();
    }

    private void Start()
    {
        MM.InputSystem.Singleton.OnEscapeInput += OnEscapeExecute;
    }

    private void OnDestroy()
    {
        MM.InputSystem.Singleton.OnEscapeInput -= OnEscapeExecute;
    }

    void OnEscapeExecute()
    {
        UIManager.Show<PausePopupUI>(UIList.PausePopupUI);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        Vector2 input = new Vector2(horizontal, vertical);

        if (Input.GetMouseButtonDown(0)) // 마우스 좌 클릭이 한번 눌러졌을 때, 발생하는 이벤트
        {
            linkedCharacter.Attack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            linkedCharacter.RangeAttack();
        }

        linkedCharacter.IsRunning = Input.GetKey(KeyCode.LeftShift);
        linkedCharacter.Move(input);
        linkedCharacter.Rotate(mouseX);


        if (Input.GetKeyDown(KeyCode.F9))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby Scene", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }
    }
}
