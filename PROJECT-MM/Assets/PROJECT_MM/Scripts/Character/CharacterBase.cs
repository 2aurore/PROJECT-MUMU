using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Windows;

public class CharacterBase : MonoBehaviour, IDamage
{
    public bool IsRunning { get; set; }

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
        animationParameterSpeed = input.sqrMagnitude > 0f ? (isValidRunning ? 2f : 0.5f) : 0f;
        animationParameterHorizontal = input.x;
        animationParameterVertical = input.y;

        Vector3 movement = new Vector3(input.x, 0f, input.y);
        transform.Translate(movement * (isValidRunning ? runSpeed : walkSpeed) * Time.deltaTime, Space.Self);
    }

    public void Rotate(float yAxis)
    {
        transform.Rotate(Vector3.up * yAxis);
    }

    public void Attack()
    {
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

    public void ApplyDamage(float damage)
    {

    }
}
