using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Animator animator;
    public bool isRunning = false;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        
        float mouseX = Input.GetAxis("Mouse X");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        isRunning = Input.GetKey(KeyCode.LeftShift);

        Vector2 input = new Vector2(horizontal, vertical);

        animator.SetFloat("Speed", input.sqrMagnitude > 0f ? isRunning ? 3f : 0.5f : 0f);
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up * mouseX);
    }
}
