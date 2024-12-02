using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1f;
    public float lifeTime = 5f;

    private void OnEnable()
    {
        // Destroy �Լ��� gameObject�� �־�θ�, �ش� ���ӿ�����Ʈ�� �ı��� �ȴ�.
        // Destory �Լ��� component [Monobehaviour Ŭ����]�� ������ ������Ʈ�� Remove Component �� �� ó�� �۵��Ѵ�.
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.TryGetComponent(out IDamage damageInterface))
        {
            damageInterface.ApplyDamage(damage);
        }
    }
}
