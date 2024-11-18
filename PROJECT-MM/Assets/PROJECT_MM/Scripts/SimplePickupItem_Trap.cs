using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePickupItem_Trap : MonoBehaviour, IPickup
{
    public string Name => "Trap";

    public GameObject trapEffect;

    public void Pickup()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject newTrapBall = Instantiate(trapEffect, transform.position + Vector3.up, Quaternion.identity);
            newTrapBall.gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }
}
