using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePickupItem : MonoBehaviour, IPickup
{
    private GameObject nearObject;
    
    private void OnTriggerStay(Collider other) 
    {
        
        if (other.tag == "Item")
        {
            nearObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Item")
        {
            nearObject = null;
        }
     }

     private void Update() {
        PickupItem();
     }

    public void PickupItem()
    {
        if (Input.GetKey(KeyCode.K) && nearObject != null) {
            Debug.Log("test");
            if (nearObject.tag == "Item")
            {
                Destroy(nearObject);
            }
        }
    }
}
