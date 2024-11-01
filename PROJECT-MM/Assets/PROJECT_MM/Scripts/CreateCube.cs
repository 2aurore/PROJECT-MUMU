using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    public GameObject cubePrefab;
    public void InstantiateCube()
    {   
        Debug.Log("test");
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }

}
