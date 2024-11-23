using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Animator animator;
    public bool isRunning = false;
    public bool isCrouching = false;
    public bool isPosing = false;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        
        float mouseX = Input.GetAxis("Mouse X");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        isRunning = Input.GetKey(KeyCode.LeftShift);

        // left control 키가 눌렸을때 상태를 전환
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            isCrouching = !isCrouching;
        }
        // T 키가 눌렸을때 상태를 전환
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            isPosing = !isPosing;
        }
        // 캐릭터가 달리는 중일 때 속도를 높이게 하고, 자세를 숙인 상태에서 이동속도 절반으로 줄임
        float dynamicMoveSpeed = isRunning ? moveSpeed * 2 : isCrouching ? moveSpeed / 2 : moveSpeed;

        Vector2 input = new Vector2(horizontal, vertical);

        animator.SetFloat("Speed", input.sqrMagnitude > 0f ? isRunning ? 3f : 0.5f : 0f);
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetBool("Crouching", isCrouching);
        animator.SetBool("Posing", isPosing);
        
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * dynamicMoveSpeed * Time.deltaTime, Space.Self);
        
        // 캐릭터가 포즈 중일 때는 마우스 위치에 따라 회전하지 않도록 함
        if (!isPosing) 
        {
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
