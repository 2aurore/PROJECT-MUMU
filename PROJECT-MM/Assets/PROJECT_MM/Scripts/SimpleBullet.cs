using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float lifeTime = 5f;

    private void Start()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

        // Start����, 5�� �ڿ� �ڱ��ڽ� GameObject�� �ı��ϴ� ����� �̸� ���ܳ���.
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamage damageInterface = collision.transform.GetComponent<IDamage>();
        damageInterface?.ApplyDamage(10f);

        Destroy(gameObject);
    }
}
