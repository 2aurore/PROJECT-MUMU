using Unity.VisualScripting;
using UnityEngine;

public class SimplePhysicisEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;
    public GameObject field;
    public float spanDelay;
    private float lastSpanTime;


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

        // if (other.gameObject.name == "Capsule")
        // {
        //     Debug.Log("Trigger Enter : "+ other.gameObject.name);
        //     // Sphere에 들어갔을 때 0.2초마다 큐브 생성
        //     InvokeRepeating("InInstantiateCube", 0f, 0.2f);
            
        // }
    }

    private void InInstantiateCube()
    {
        // 큐브 생성 로직
        field.GetComponent<CreateCube>().InstantiateCube();
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.name == "Capsule")
        {
            Debug.Log("Trigger Stay : "+ other.gameObject.name);
            // Sphere에 stay중일 때  큐브 생성
            // Debug.Log($"lastSpanTime {lastSpanTime} ::: spanDelay {spanDelay}");
            if (Time.time - lastSpanTime > spanDelay)
            {
                field.GetComponent<CreateCube>().InstantiateCube();
                lastSpanTime = Time.time;
            }
                
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        // if (other.gameObject.name == "Capsule")
        // {
        //     Debug.Log("Trigger Exit : "+ other.gameObject.name);
        //     // Sphere에서 나왔을 때 큐브 생성 로직 해제
        //     CancelInvoke("InInstantiateCube");
        // }
    }
}
