using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePhysicisEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;
    public GameObject field;


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

        if (other.gameObject.name == "Capsule")
        {
            Debug.Log("Trigger Enter : "+ other.gameObject.name);
            cubePrefab.SetActive(true);
            
            field.GetComponent<CreateCube>().InstantiateCube();
            // Vector3 position = new Vector3(0f, 9f, 5f);
            // for (int i = 0; i < 10; i++)
            // {
            //     // Instantiate(Cube, position, Quaternion.identity);
            //     Instantiate(Cube, field.transform, true);
            // }
            
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
