using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    
    public CharactorBase linkedCharactor;

    private void Awake() {
        linkedCharactor = GetComponent<CharactorBase>();
    }

    private void Update() {
        
        float mouseX = Input.GetAxis("Mouse X");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        linkedCharactor.IsRunning = Input.GetKey(KeyCode.LeftShift);
        

        // left control 키가 눌렸을때 상태를 전환
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            linkedCharactor.IsCrouching = !linkedCharactor.IsCrouching;
        }
        // T 키가 눌렸을때 상태를 전환
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            linkedCharactor.IsPosing = !linkedCharactor.IsPosing;
        }
        // 마우스 좌클릭 시 공격 모션 
        if (Input.GetMouseButtonDown(0) && !linkedCharactor.IsPosing && !linkedCharactor.IsCrouching)
        {
            // 이미 공격 모션 중일 때 새롭게 공격모션을 취할 수 없도록 적용
            if (!linkedCharactor.IsAttack)
            {
                linkedCharactor.Attack();
            }
        }

        if (!linkedCharactor.IsAttack)
        {
            Vector2 input = new Vector2(horizontal, vertical);
            linkedCharactor.Move(input);
            linkedCharactor.Rotate(mouseX);
        }

        
    }
}
