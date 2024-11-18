using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePickupSensor : MonoBehaviour
{
    public float sensorRadius = 3f;
    public LayerMask sensorLayers;

    public List<GameObject> detectedObjects = new List<GameObject>();
    private List<IPickup> detectedPickupItems = new List<IPickup>();

    private void Update() {

        detectedObjects.Clear();
        detectedPickupItems.Clear();
        Collider[] overlapped = Physics.OverlapSphere(transform.position, sensorRadius, sensorLayers);

        for (int i = 0; i < overlapped.Length; i++)
        {
            IPickup pickupInterface = overlapped[i].transform.root.GetComponent<IPickup>();
            if (pickupInterface != null) 
            {
                detectedObjects.Add(overlapped[i].transform.root.gameObject);
                detectedPickupItems.Add(pickupInterface);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < detectedPickupItems.Count; i++)
            {
                detectedPickupItems[i].Pickup();
            }
        }
    }
}