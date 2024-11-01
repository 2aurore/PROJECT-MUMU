using UnityEngine;

public class CreateCube : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform field;

    public void InstantiateCube()
    {   
        // Instantiate(cubePrefab, transform.position, Quaternion.identity);
        GameObject cube = Instantiate(cubePrefab, field);
        cube.transform.position = transform.position;

        Invoke("DestroyCube", 3f);
    }

    private void DestroyCube()
    {
        if (field.childCount.Equals(0)) return;

        Destroy(field.GetChild(0).gameObject);
    }

}
