using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePhysicisEvent : MonoBehaviour
{
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
