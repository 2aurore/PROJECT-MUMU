using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrapCylinder : MonoBehaviour, IDamage
{
    private Renderer meshRenderer;

    private float flickerTime = 3f;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<Renderer>();
    }

    public void ApplyDamage(float damage)
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        float startTime = Time.time;
        while (Time.time - startTime < flickerTime)
        {
            meshRenderer.material.color = Color.red;

            yield return new WaitForSeconds(0.1f);

            meshRenderer.material.color = Color.white;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
