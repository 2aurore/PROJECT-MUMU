using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttacker : MonoBehaviour
{
    public float fireRate = 1f; 
    public GameObject bullet;
    public Transform firePoint;

    private float lastFireTime = 0f;

    private void Update() 
    {
        
        if (Time.time - lastFireTime > fireRate)
        {
            Fire();
        }
    }

    void Fire() 
    {
        lastFireTime = Time.time;  
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        newBullet.gameObject.SetActive(true);

        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(firePoint.forward * 10f, ForceMode.Impulse);

    }


}
