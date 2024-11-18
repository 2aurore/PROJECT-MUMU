using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePickupItem : MonoBehaviour, IPickup
{
    public string Name => itemName;


    public string itemName;

    public void Pickup()
    {
        Destroy(gameObject);
    }
}
