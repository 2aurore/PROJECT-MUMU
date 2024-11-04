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
            // coroutine은 GameObject가 파괴되면 함께 사라짐.
            currentCoroutine = SpawnFallingCubeCoroutine();
            StartCoroutine(currentCoroutine);
            
            // Invoke는 실행 후 GameObject가 파괴되어도 지정된 delay 시간 이후에 로직을 수행함.
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
