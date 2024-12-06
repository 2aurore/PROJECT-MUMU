using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1f;
    public float lifeTime = 5f;

    private void OnEnable() {
        // Destory 함수에 gameObject를 넣어두면, 해당 게임 오브젝트가 파괴 된다
        // Destory 함수에 component (Monobehavior 클래스)를 넣으면 컴포넌트가 remove compoenet가 된 것 처럼 사라진다
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
