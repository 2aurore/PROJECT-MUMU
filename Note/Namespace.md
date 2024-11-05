네임스페이스는 클래스들의 묶음으로, 
프로젝트 규모가 커질 때 각종 이름의 충돌 문제를 해결해주는 방법으로 사용할 수 있다.

1. 네임스페이스 선언
```C#
namespace 네임스페이스-이름
{
    class A { }
    class B { }
    ....
} 
```
  1-1. 네임스페이스 중첩 선언 방법

```C#
namespace 네임스페이스-이름1
{
   namesapce 네임스페이스-이름-2 
    {        
        class A { }
        class B { }
        ....
    }
} 
```
```C#
namespace 네임스페이스-이름1.네임스페이스-이름-2 
{
    class A { }
    class B { }
    ....
} 
```

2. 네임스페이스 참조
2-1 전체 네임스페이스를 다 적어주는 방식.
```C#
UnityEngine.Debug.Log("네임스페이스 1");
```
2-2. using 지시문을 사용.
    using 지시문은 선언문에 using 지시문을 선언해줍니다.
```C#
using UnityEngine;

public class NamespacesExample : MonoBehaviour
{
    void Start()
    {
        Debug.Log("네임스페이스 1");
    }
}
```

