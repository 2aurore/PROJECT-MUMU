using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // 변수 선언 시 public 인 경우 Inspector 에서 편집할 수 있음
    // But, [SerializeField] Attribute를 사용하면 private 인 경우에도 Inspector 에서 확인할 수 있음 
    public float speed = 3f;

    private void Update()
    {
        Vector3 movement = Vector3.zero;

        float mouseX = Input.GetAxis("Mouse X");
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        movement.x = xInput;
        movement.z = zInput;

        // transform.position += movement * speed * Time.deltaTime;
        // Time.deltaTime : Update 함수가 한번 실행되는데까지 걸린 실제 시간
        // ex) 1초에 Update 함수가 60번 호출되었다면 => Update 함수 1번 당 1/60초
        // 1초 동안 수행되는 수치를 변환하고 싶을 때 사용하는 분모 값

        transform.Translate(movement * speed * Time.deltaTime, Space.Self);
        transform.Rotate(new Vector3(0f, 1f, 0f), mouseX);

    }

}
