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
        if (Input.GetMouseButtonDown(0))
        {
            linkedCharactor.Attack();
        }


        Vector2 input = new Vector2(horizontal, vertical);
        linkedCharactor.Move(input);
        linkedCharactor.Rotate(mouseX);

        
    }
}
