using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBackRoom : MonoBehaviour
{
    public GameObject fallingCube;
    public Transform spawnPoint;
    public Rigidbody backroomRigidbody;

    public int spawnCount = 10;

    private IEnumerator currentCoroutine;

    private IEnumerator SpawnFallingCubeCoroutine()
    {
        yield return new WaitForSeconds(3f);

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject newCube = Instantiate(fallingCube, spawnPoint.position, Quaternion.identity);
            newCube.gameObject.SetActive(true);
        }
    }

    private void SpawnFallingCubeInvoke()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject newCube = Instantiate(fallingCube, spawnPoint.position, Quaternion.identity);
            newCube.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentCoroutine = SpawnFallingCubeCoroutine();
            StartCoroutine(currentCoroutine);
            
            Invoke(nameof(SpawnFallingCubeInvoke), 3f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(currentCoroutine);
        }
    }
}
