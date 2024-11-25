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

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        Vector2 input = new Vector2(horizontal, vertical);

        if (Input.GetMouseButtonDown(0)) // ���콺 �� Ŭ���� �ѹ� �������� ��, �߻��ϴ� �̺�Ʈ
        {
            linkedCharacter.Attack();
        }

        linkedCharacter.IsRunning = Input.GetKey(KeyCode.LeftShift);
        linkedCharacter.Move(input);
        linkedCharacter.Rotate(mouseX);
    }
}
