using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSandbackSphere : MonoBehaviour, IDamage
{
    public float maxHealth = 10000;
    public float curHealth = 0;

    public float minScale = 0.5f;
    private Vector3 startingScale;

    private void Start()
    {
        curHealth = maxHealth;
        startingScale = transform.localScale;
    }

    public void ApplyDamage(float damage)
    {
        curHealth -= damage;

        float percent = curHealth / maxHealth;
        transform.localScale = startingScale * (minScale + percent * (1 - minScale));

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
