using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePickupSensor : MonoBehaviour
{

    public float sensorRadius = 3f;
    public LayerMask sensorLayers;

    public List<GameObject> detectedObjects = new List<GameObject>();
    public List<IPickup> detectedPickupItems = new List<IPickup>();

    private void Update()
    {
        detectedObjects.Clear();
        detectedPickupItems.Clear();
        Collider[] overlapped = Physics.OverlapSphere(transform.position, sensorRadius, sensorLayers);
        for (int i = 0; i < overlapped.Length; i++)
        {
            IPickup pickInterface = overlapped[i].transform.root.GetComponent<IPickup>();
            if (pickInterface != null)
            {
                detectedObjects.Add(overlapped[i].transform.root.gameObject);
                detectedPickupItems.Add(pickInterface);
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
