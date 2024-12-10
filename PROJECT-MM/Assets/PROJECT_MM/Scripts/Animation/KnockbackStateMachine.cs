using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Animator 에 붙일 수 있는 컴포넌트 속성으로 선언
public class KnockbackStateMachine : StateMachineBehaviour
{

    private CharactorBase charactor;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Animator의 Start와 같은 역할을 함 => state가 처음 들어갈 때 호출
        charactor = animator.GetComponent<CharactorBase>();
        // charactor.isKnockBack = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Animator에서 현재 state가 빠져나갈 때 호출됨
        charactor = animator.GetComponent<CharactorBase>();
        // charactor.isKnockBack = false;

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Animator의 Update와 같은 역할을 함
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Animator의 state가 갱신할 때 호출됨

    }
}
