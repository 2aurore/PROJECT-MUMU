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
                gameObject.SetActive(false);
            }
        }
    }

}
