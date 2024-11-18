### coroutine
> update가 아닌 곳에서도 반복적으로 코드가 실행되어야할 필요가 있을 때 주로 사용<br>
> 필요한 순간에만 반복하고 필요하지 않을 때에는 전혀 사용하지 않음으로써 자원관리에 효과적
  
1. coroutine의 필수 조건<br>
1-1 코루틴은 IEnumerator라는 반환형으로 시작해야함<br>
1-2 yield retrun이 반드시 함수 내부에 존재해야함<br>
```C#
IEnumerator 함수이름()
{
	yield return // + 조건
    // 함수 내용
}
```
   
2. yield return<br>
> yield return의 조건에 따라 coroutine 동작을 제어할 수 있음<br>

[yield return 종류](https://yeobi27.tistory.com/411)<br>

yield return null : 다음 프레임까지 대기<br>
yield return new WaitForSeconds(flaot) : 지정한 초 만큼 대기<br>
yield return new WaitFixedUpdate() : 다음 FixedUpdate 까지 대기<br>
yield return new WaitForEndOfFrame() : 모든 랜더링 작업이 끝날 때까지 대기<br>
yield return startCoroutiune(string) : 다른 코루틴이 끝날 때까지 대기<br>
yield return new www(string) : 웹 통신 작업이 끝날 때까지 대기<br>
yield return new AsyncIoeration : 비동기 작업이 끝날 때까지 대기( 씬 로딩);<br>
   
3. Invoke 와의 차이점<br>
3-1 Invoke와 다르게 매개변수를 사용할 수 있음<br>
```C#
StartCoroutine( 메소드이름( 매개변수1, 매개변수2 ) );
StartCoroutine( "메소드이름", 매개변수 );
```
