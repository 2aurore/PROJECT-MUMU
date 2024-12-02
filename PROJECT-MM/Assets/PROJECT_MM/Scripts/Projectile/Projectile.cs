using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1f;
    public float lifeTime = 5f;

    private void OnEnable()
    {
        // Destroy 함수에 gameObject를 넣어두면, 해당 게임오브젝트가 파괴가 된다.
        // Destory 함수에 component [Monobehaviour 클래스]를 넣으면 컴포넌트가 Remove Component 된 것 처럼 작동한다.
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
