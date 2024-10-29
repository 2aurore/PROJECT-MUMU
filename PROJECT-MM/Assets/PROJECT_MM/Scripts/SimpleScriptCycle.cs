using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScriptCycle : MonoBehaviour
{
    private void Awake() 
    {
        Debug.Log("Awake!");
    }

    private void OnEnable()
    {
        // GameObject가 Active 될 때 호출
        Debug.Log("OnEnable!");
    }

    private void Start()
    {
        Debug.Log("Start!");
    }
    
    private void Update()
    {
        Debug.Log("Update!");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate!");
    }
    
    private void LateUpdate()
    {
        Debug.Log("LateUpdate!");
    }

    private void OnDisable()
    {
        // GameObject가 InActive 될 때 호출
        Debug.Log("OnDisable!");
    }

    private void OnDestroy()
    {
        // GameObject가 Delete 될 때 호출
        Debug.Log("OnDestroy!");
    }

}
