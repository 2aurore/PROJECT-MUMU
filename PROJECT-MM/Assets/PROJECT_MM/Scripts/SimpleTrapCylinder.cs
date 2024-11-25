using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrapCylinder : MonoBehaviour, IDamage
{
    private Renderer meshRenderer;
    private float filkerTime = 3f;

    private void Awake() {
        meshRenderer  = GetComponentInChildren<Renderer>();
    }

    private void Update() 
    {
    }

    public void ApplyDamage(float damage)
    {
        StartCoroutine(Filcker());
    }

    IEnumerator Filcker() 
    {
        float startTime = Time.time;
        while (Time.time - startTime < filkerTime)
        {
            meshRenderer.material.color = Color.red;

            yield return new WaitForSeconds(0.01f);
            
            meshRenderer.material.color = Color.white;

            yield return new WaitForSeconds(0.01f);


        }
    }
}
