using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorBase : MonoBehaviour, IDamage
{

  public bool IsRunning { get; set; }
  public bool IsCrouching { get; set; }
  public bool IsPosing { get; set; }
  public bool IsAttack { get; set; }
  public bool IsAlive => currentHP > 0f;
  public float AttackCombo { get; set; }

  // attack 범위를 볼 수 있게 해주는 기즈모 추가
  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position + (transform.forward * attackRange), attackRadius);

    Gizmos.color = Color.blue;
    Vector3 secondGizmoPosition = transform.position + (transform.forward * attackRange) + (Vector3.up * attackOffset);
    Gizmos.DrawWireSphere(secondGizmoPosition, attackRadius);
  }

  public float moveSpeed = 2f;
  public Animator animator;

  public float attackRange = 1f;
  public float attackRadius = 1f;
  public float attackOffset = 1f;


  public float currentHP;
  public float maxHP;
  public float currentSP;
  public float maxSP;

  private bool isValidRunning;
  private float animationParameterSpeed;
  private float animationParameterHorizontal;
  private float animationParameterVertical;

  public GameObject rangeAttackBulletOriginal;
  public Transform rangeAttackStartPoint;
  public float rangeAttackRequireSP = 50f;


  public float circularAttackAngle = 90f;
  // private float circularAttackRange = 3f;

  public float rangeAttackDistance = 5f;

  private void Awake()
  {
    animator = GetComponent<Animator>();
  }

  private void Start()
  {
    currentHP = maxHP;
    currentSP = maxSP;

    IngameUI.Instance.SetHP(currentHP, maxHP);
    IngameUI.Instance.SetSP(currentSP, maxSP);

    IsAttack = false;
    AttackCombo = 0f;
  }

  private void Update()
  {
    if (!IsAlive)
    {
      return;
    }


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
    if (!IsAlive)
    {
      return;
    }


    animationParameterSpeed = input.sqrMagnitude > 0f ? IsRunning ? 3f : 0.5f : 0f;
    animationParameterHorizontal = input.x;
    animationParameterVertical = input.y;

    // 캐릭터가 달리는 중일 때 속도를 높이게 하고, 자세를 숙인 상태에서 이동속도 절반으로 줄임
    float dynamicMoveSpeed = IsRunning ? moveSpeed * 2 : IsCrouching ? moveSpeed / 2 : moveSpeed;

    Vector3 movement = new Vector3(input.x, 0f, input.y);
    transform.Translate(movement * dynamicMoveSpeed * Time.deltaTime, Space.Self);

    // if (input.x != 0 || input.y != 0)
    // {
    //   string log = IsRunning ? "running..." : IsCrouching ? "crouch..." : "move...";
    //   LogUI.Instance.AddLogMessage("system", log);
    // }
  }

  public void Rotate(float yAxis)
  {
    if (!IsAlive)
    {
      return;
    }

    // 캐릭터가 포즈 중일 때는 마우스 위치에 따라 회전하지 않도록 함
    if (!IsPosing)
    {
      transform.Rotate(Vector3.up * yAxis);
    }
  }

  public void Pose()
  {
    animator.SetTrigger("Pose Trigger");
    IsPosing = !IsPosing;

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
    Collider[] overlapped = Physics.OverlapSphere(calculatePivotPosition, attackRadius);
    for (int i = 0; i < overlapped.Length; i++)
    {
      Debug.Log($"Overlapped: {overlapped[i].name}");

      if (overlapped[i].transform.root.TryGetComponent(out IDamage damageInterface))
      {
        // 자기 자신에게 데미지 주지 않도록 적용
        if (overlapped[i].transform.root.gameObject == this.gameObject)
          continue;

        damageInterface.ApplyDamage(10f);
      }
    }
  }
  /// <summary> 이 메서드는 애니메이션 이벤트로 호출된다. </summary>
  public void LogicalAttack2()
  {
    Vector3 calculatePivotPosition = transform.position + (transform.forward * attackRange) + (Vector3.up * attackOffset);
    Collider[] overlapped = Physics.OverlapSphere(calculatePivotPosition, attackRadius);
    for (int i = 0; i < overlapped.Length; i++)
    {
      Debug.Log($"Overlapped: {overlapped[i].name}");

      if (overlapped[i].transform.root.TryGetComponent(out IDamage damageInterface))
      {
        // 자기 자신에게 데미지 주지 않도록 적용
        if (overlapped[i].transform.root.gameObject == this.gameObject)
          continue;

        damageInterface.ApplyDamage(10f);
      }
    }
  }

  public void RangeAttack()
  {
    if (currentSP < rangeAttackRequireSP)
    {
      return;
    }

    currentSP -= rangeAttackRequireSP;
    IngameUI.Instance.SetSP(currentSP, maxSP);

    animator.SetTrigger("RangeAttack Trigger");
  }

  public void LogicalRangeAttack()
  {
    #region 투사체로 검증하는 방법
    // GameObject newBullet = Instantiate(rangeAttackBulletOriginal, rangeAttackStartPoint.position , rangeAttackStartPoint.rotation);
    // newBullet.gameObject.SetActive(true);

    // Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
    // bulletRigidbody.AddForce(rangeAttackStartPoint.forward * 10f, ForceMode.Impulse);
    #endregion

    #region 부채꼴 모양의 물리를 검사하는 방법

    // Collider[] overlapped = Physics.OverlapSphere(rangeAttackStartPoint.position, circularAttackRange);
    // for (int i = 0; i < overlapped.Length; i++)
    // {
    //   Vector3 detectedPosition = overlapped[i].transform.root.position;
    //   // 타겟 - 내 위치 
    //   Vector3 direction = (detectedPosition - transform.position).normalized;

    //   float angle = Vector3.Angle(transform.forward, direction);
    //   if (angle < circularAttackAngle * 0.5f) 
    //   {
    //     if (overlapped[i].transform.root.TryGetComponent(out IDamage damageInterface))
    //     {
    //       damageInterface.ApplyDamage(10f);
    //     }
    //   }
    //   Debug.DrawLine(rangeAttackStartPoint.position, detectedPosition + Vector3.up, Color.yellow, 1f);
    // } 
    #endregion

    #region 레이캐스트를 이용해서 [레이저를 하나 쏴서] 검증하는 방법

    if (Physics.Raycast(rangeAttackStartPoint.position, rangeAttackStartPoint.forward, out RaycastHit hit, rangeAttackDistance))
    {
      if (hit.collider.transform.root.TryGetComponent(out IDamage damageInterface))
      {
        damageInterface.ApplyDamage(10f);
      }

      Debug.DrawLine(rangeAttackStartPoint.position, rangeAttackStartPoint.position + rangeAttackStartPoint.forward * rangeAttackDistance, Color.yellow, 1f);
    }
    #endregion


  }
  /// <summary> 이 메서드는 애니메이션 이벤트로 호출된다. </summary>
  public void AttackEnd()
  {
    IsAttack = false;

    if (AttackCombo >= 3)
    {
      AttackCombo = 0f;
    }
  }

  public void ApplyDamage(float damage)
  {
    if (IsAttack)
    {
      // 공격 모션 도중 데미지를 받아 AttackEnd 실행 전에 피격되는 경우 
      IsAttack = false;
    }

    float prevHP = currentHP;
    currentHP -= damage;
    currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    IngameUI.Instance.SetHP(currentHP, maxHP);

    // 체력이 0 아래로 떨어지고 현 상태가 IsAlive 일때만 동작하도록 함
    Debug.Log("currentHP:: " + currentHP);
    Debug.Log("prevHP:: " + prevHP);

    if (currentHP <= 0f && prevHP > 0)
    {
      animator.SetTrigger("Dead Trigger");
      LogUI.Instance.AddLogMessage("system", "Dead");
    }

    if (prevHP <= 0)
    {
      return;
    }
    if (damage < 10)
    {
      animator.SetTrigger("Hit Trigger");
      LogUI.Instance.AddLogMessage("system", "Hit");

    }
    else
    {
      // 큰 데미지가 들어오는 경우 캐릭터를 넉백 시킴
      animator.SetTrigger("Down Trigger");
      LogUI.Instance.AddLogMessage("system", "Hit");

    }
  }
}
