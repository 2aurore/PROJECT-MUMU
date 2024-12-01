using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorBase : MonoBehaviour, IDamage
{
    public bool IsRunning { get; set; }
    public bool IsCrouching { get; set; }
    public bool IsPosing { get; set; }
    public bool IsAttack { get; set; }
    public float AttackCombo { get; set; }

    private void OnDrawGizmos() {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position + (transform.forward * attackRange), attackRadius);
    }
  
    public float moveSpeed = 2f;
    public Animator animator;

    public float attackRange = 1f;
    public float attackRadius = 1f;


    public float currentHP;
    public float maxHP;
    public float currentSP;
    public float maxSP;

    private bool isValidRunning;
    private float animationParameterSpeed;
    private float animationParameterHorizontal;
    private float animationParameterVertical;


    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        currentHP = maxHP;
        currentSP = maxSP;

        IngameUI.Instance.SetHP(currentHP, maxHP);
        IngameUI.Instance.SetSP(currentSP, maxSP);

        IsAttack = false;
        AttackCombo = 0f;
    }
    
    private void Update() {
      
        isValidRunning = IsRunning && currentSP > 0;
        if (isValidRunning) 
        {
            currentSP -= Time.deltaTime;
        }
        else
        {
            currentSP += Time.deltaTime;
        }
        currentSP = Mathf.Clamp(currentSP, 0f, maxSP); // SP 값이 0보다 작아지지 않고 max값 보다 커지지 않기
        IngameUI.Instance.SetSP(currentSP, maxSP);

        animator.SetFloat("Speed", animationParameterSpeed);
        animator.SetFloat("Horizontal", animationParameterHorizontal);
        animator.SetFloat("Vertical", animationParameterVertical);
        animator.SetBool("Crouching", IsCrouching);
        animator.SetBool("Posing", IsPosing);
        animator.SetFloat("Attack Combo", AttackCombo);
        
    }

    public void Move(Vector2 input) 
    {
        animationParameterSpeed = input.sqrMagnitude > 0f ? IsRunning ? 3f : 0.5f : 0f;
        animationParameterHorizontal = input.x;
        animationParameterVertical = input.y;

        // 캐릭터가 달리는 중일 때 속도를 높이게 하고, 자세를 숙인 상태에서 이동속도 절반으로 줄임
        float dynamicMoveSpeed = IsRunning ? moveSpeed * 2 : IsCrouching ? moveSpeed / 2 : moveSpeed;

        Vector3 movement = new Vector3(input.x, 0f, input.y);
        transform.Translate(movement * dynamicMoveSpeed * Time.deltaTime, Space.Self);

    }

    public void Rotate(float yAxis) 
    {
      // 캐릭터가 포즈 중일 때는 마우스 위치에 따라 회전하지 않도록 함
        if (!IsPosing) 
        {
            transform.Rotate(Vector3.up * yAxis);
        }
    }

    public void Attack()
    {
      animator.SetTrigger("Attack Trigger");
      IsAttack = true;
      AttackCombo += 1f;
    }

    /// <summary> 이 메서드는 애니메이션 이벤트로 호출된다. </summary>
    public void LogicalAttack() 
    {
      Vector3 calculatePivotPosition = transform.position + (transform.forward * attackRange);
      Collider[] overlapped =  Physics.OverlapSphere(calculatePivotPosition, attackRadius);
      for (int i = 0; i < overlapped.Length; i++) 
      {
        Debug.Log($"Overlapped: {overlapped[i].name}");

        if (overlapped[i].transform.root.TryGetComponent(out IDamage damageInterface)) 
        {
          damageInterface.ApplyDamage(10f);
        }
      }
    }

    /// <summary> 이 메서드는 애니메이션 이벤트로 호출된다. </summary>
    public void AttackEnd()
    {
      IsAttack = false;

      if (AttackCombo == 3)
      {
        AttackCombo = 0f;
      }
    }

    public void ApplyDamage(float damage)
    {
        
    }
}
