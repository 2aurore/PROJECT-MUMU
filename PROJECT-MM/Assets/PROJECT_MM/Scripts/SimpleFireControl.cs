using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFireControl : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 0.3f;

    public GameObject bulletOriginal;

    public float lastFireTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Time.time : 게임이 시작한 이후 경과된 시간 
            if (Time.time > lastFireTime + fireRate)
            {
                lastFireTime = Time.time;

                GameObject newBullet = Instantiate(bulletOriginal, firePoint.position, firePoint.rotation);
                newBullet.gameObject.SetActive(true);
            }
        }
    }
}
