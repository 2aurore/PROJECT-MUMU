using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Windows;

public class CharacterBase : MonoBehaviour, IDamage
{
    public bool IsRunning { get; set; }
    public bool IsAlive => currentHP > 0f;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + (transform.forward * attackRange), attackRadius);
    }

    public Animator animator;

    public float walkSpeed = 2f;
    public float runSpeed = 3f;

    public float attackRange = 1f;
    public float attackRadius = 1f;

    public float currentHP;
    public float currentSP;
    public float maxHP;
    public float maxSP;

    private bool isValidRunning;
    private float animationParameterSpeed;
    private float animationParameterHorizontal;
    private float animationParameterVertical;


    public GameObject rangeAttackBulletOriginal;
    public Transform rangeAttackStartPoint;
    public float rangeAttackRequireSP = 50f;


    public float circularAttackAngle = 90f;
    public float circularAttackRange = 3f;


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
        currentSP = Mathf.Clamp(currentSP, 0f, maxSP); // SP 값이 0보다 작아지지않고, max 값보다 넘지않도록 보정
        IngameUI.Instance.SetSP(currentSP, maxSP);

        animator.SetFloat("Speed", animationParameterSpeed);
        animator.SetFloat("Horizontal", animationParameterHorizontal);
        animator.SetFloat("Vertical", animationParameterVertical);
    }

    public void Move(Vector2 input)
    {
        if (!IsAlive)
            return;

        animationParameterSpeed = input.sqrMagnitude > 0f ? (isValidRunning ? 2f : 0.5f) : 0f;
        animationParameterHorizontal = input.x;
        animationParameterVertical = input.y;

        Vector3 movement = new Vector3(input.x, 0f, input.y);
        transform.Translate(movement * (isValidRunning ? runSpeed : walkSpeed) * Time.deltaTime, Space.Self);
    }

    public void Rotate(float yAxis)
    {
        if (!IsAlive)
        {
            return;
        }

        transform.Rotate(Vector3.up * yAxis);
    }

    public void Attack()
    {
        if (!IsAlive)
        {
            return;
        }

        animator.SetTrigger("Attack Trigger");
    }

    /// <summary> 이 메서드는 애니메이션 이벤트로 호출 된다. </summary>
    public void LogicalAttack()
    {
        Vector3 calculatePivotPosition = transform.position + (transform.forward * attackRange);
        Collider[] overlapped = Physics.OverlapSphere(calculatePivotPosition, attackRadius);
        for (int i = 0; i < overlapped.Length; i++)
        {
            if (overlapped[i].transform.root.TryGetComponent(out IDamage damageInterface))
            {
                damageInterface.ApplyDamage(10f);
            }
        }
    }

    public void RangeAttack()
    {
        if (currentSP < rangeAttackRequireSP && !IsAlive)
            return;

        currentSP -= rangeAttackRequireSP;
        IngameUI.Instance.SetSP(currentSP, maxSP);

        animator.SetTrigger("RangeAttack Trigger");
    }

    public void LogicalRangeAttack()
    {
        #region 투사체로 검출 하는 방법
        //GameObject newBullet = Instantiate(rangeAttackBulletOriginal, rangeAttackStartPoint.position, rangeAttackStartPoint.rotation);
        //newBullet.gameObject.SetActive(true);
        //Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        //bulletRigidbody.AddForce(rangeAttackStartPoint.forward * 10f, ForceMode.Impulse);
        #endregion

        #region 부채꼴 모양의 물리를 검사하는 방법
        //Collider[] overlapped = Physics.OverlapSphere(rangeAttackStartPoint.position, circularAttackRange);
        //for (int i = 0; i < overlapped.Length; i++)
        //{
        //    Vector3 detectedPosition = overlapped[i].transform.root.position;
        //    Vector3 direction = (detectedPosition - transform.position).normalized;
        //    float angle = Vector3.Angle(transform.forward, direction);
        //    if (angle < circularAttackAngle * 0.5f)
        //    {
        //        if (overlapped[i].transform.root.TryGetComponent(out IDamage damageInterface))
        //        {
        //            damageInterface.ApplyDamage(10f);
        //        }
        //    }
        //    Debug.DrawLine(rangeAttackStartPoint.position, detectedPosition + Vector3.up, Color.red, 1f);
        //}
        #endregion

        #region 레이캐스트를 이용해서[레이저를 하나 쏴서] 검출하는 방법
        //if (Physics.Raycast(rangeAttackStartPoint.position, rangeAttackStartPoint.forward, out RaycastHit hit, rangeAttackDistance))
        //{
        //    if (hit.collider.transform.root.TryGetComponent(out IDamage damageInterface))
        //    {
        //        damageInterface.ApplyDamage(10f);
        //    }
        //}

        //Debug.DrawLine(
        //    rangeAttackStartPoint.position, 
        //    rangeAttackStartPoint.position + rangeAttackStartPoint.forward * rangeAttackDistance, 
        //    Color.red, 
        //    1f);
        #endregion
    }

    public void ApplyDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        IngameUI.Instance.SetHP(currentHP, maxHP);

        if (currentHP <= 0f)
        {
            animator.SetTrigger("Dead Trigger");
        }
    }
}
