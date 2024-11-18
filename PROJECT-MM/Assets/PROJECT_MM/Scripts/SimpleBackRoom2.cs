using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBackRoom2 : MonoBehaviour
{
    public Rigidbody backroomRigidbody;

    public int inputBullet = 0;
    public int bulletCount = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            inputBullet += 1;

            if (inputBullet >= bulletCount) 
            {
                // 1. backroom 전체를 비활성화
                // gameObject.SetActive(false);
                
                // 2. backroom 전체를 파괴
                Destroy(gameObject);

                // 3. backroom 하위의 wall1~3 만 파괴
                // GameObject backroomVisual = gameObject.transform.GetChild(0).gameObject;
                // for (int i = 0; i < backroomVisual.transform.childCount - 1; i++)
                // {
                //     Destroy(backroomVisual.transform.GetChild(0).gameObject);
                // }
                
            }
        }
    }

}
