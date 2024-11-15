### Invoke
> 설정한 시간만큼 함수 시작 시간을 지연시킴

```C#
Invoke(nameof({methodName}), {float 지연시간});
```
이때 `nameof()`를 사용하면 코드 에디터에서 함수 references 여부를 확인할 수 있다    

***
### InvokeRepeating
> 처음 함수를 실행할 때, 일정 시간 지연 후, 일정 시간 마다 반복
```C#
Invoke(nameof({methodName}), {float 지연 시간}, {float 지연 후 반복할 시간});
```

***
### CancelInvoke
> 현재 반복되고 있는 Invoke를 취소시킴
```C#
CancelInvoke(nameof({methodName}));
```

***
### coroutine과의 차이점
|coroutine|Invoke|
|---|---|
|GameObject가 파괴되면 함께 사라짐|실행 후 GameObject가 파괴되어도 지정된 delay 시간 이후에 로직을 수행함|
