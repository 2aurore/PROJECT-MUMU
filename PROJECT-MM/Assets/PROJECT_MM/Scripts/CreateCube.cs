using UnityEngine;

public class CreateCube : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform field;

    public void InstantiateCube()
    {   
        // Instantiate(cubePrefab, transform.position, Quaternion.identity);
        // 큐브를 정해진 필드 오브젝트 하위로 생성
        GameObject cube = Instantiate(cubePrefab, field);
        // 큐브가 생성될 위치를 현재 오브젝트의 position으로 설정
        cube.transform.position = transform.position;
        // 생성된 큐브를 3초 뒤에 파괴
        Invoke("DestroyCube", 3f);
    }

    private void DestroyCube()
    {   
        if (field.childCount.Equals(0)) return;

        // 현재 필드에 생성된 순서대로 파괴 실행
        Destroy(field.GetChild(0).gameObject);
    }

}
