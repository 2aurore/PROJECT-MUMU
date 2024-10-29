using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePhysicisEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    private void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("Collision Enter : "+ collision.gameObject.name);
    }
    private void OnCollisionStay(Collision collision) 
    {
        Debug.Log("Collision Stay : "+ collision.gameObject.name);

    }
    private void OnCollisionExit(Collision collision) 
    {
        Debug.Log("Collision Exit : "+ collision.gameObject.name);

    }
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Trigger Enter : "+ other.gameObject.name);

        if (other.gameObject.name == "Capsule")
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(cubePrefab);
            }
                Destroy(cubePrefab, 10f);
            
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        Debug.Log("Trigger Stay : "+ other.gameObject.name);


    }
    private void OnTriggerExit(Collider other) 
    {
        Debug.Log("Trigger Exit : "+ other.gameObject.name);

    }
}
