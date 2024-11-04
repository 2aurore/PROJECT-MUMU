using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAngrySphere : MonoBehaviour, IDamage
{
    public float limitScale = 5f;
    public float increasedScale = 0f;

    private Vector3 startingScale;

    private void Start()
    {
        startingScale = transform.localScale;
    }

    public void ApplyDamage(float damage)
    {
        increasedScale += Time.deltaTime;

        transform.localScale = startingScale * (1 + increasedScale);


        if (increasedScale >= limitScale)
        {
            Destroy(gameObject);
        }
    }
}
