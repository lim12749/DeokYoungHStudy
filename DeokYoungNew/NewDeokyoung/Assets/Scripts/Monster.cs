using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : LivingEntity
{
    public float DieTime;
    public int hp;
    public Animator MonsterAnim;
    public Rigidbody MonsterRigidbody;
    public CapsuleCollider MonsterCollider;
    //public Slider hpUI;
    public UnityEngine.AI.NavMeshAgent pathFinder;
    public GameObject Target;
    public bool isMove = false;
    public bool isRun = false;

    [SerializeField] private LivingEntity targetEntity; // ������ ���

    [Header("Attack Pramiter")]
    public float damage = 20f; // ���ݷ�
    public float timeBetAttack = 0.5f; // ���� ����
    private float lastAttackTime; // ������ ���� ����
    private void Start()
    {
        //hpUI.maxValue = hp;
    }
    private void Update()
    {
        pathFinder.SetDestination(Target.transform.position);
        if (Vector3.Distance(Target.transform.position, transform.position) < 3f)
        {
            isRun = false;
            isMove = true;
            MonsterMoveAnim();
        }
        else
        {
            isRun = true;
            isMove = false;
            MonsterRunAnim();
        }
        
    }
    public void MonsterRunAnim()
    {
        MonsterAnim.SetBool("IsRun", isRun);
    }
    public void MonsterMoveAnim()
    {
        //isMove = pathFinder.velocity != Vector3.zero;

        MonsterAnim.SetBool("IsMove", isMove);
    }
    public void SetDamage(int _value)
    {
        hp = hp - _value;
        //hpUI.value = hp;
        if (hp <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        //is Die play Animator
        MonsterAnim.SetTrigger("IsDie");
        //is Die Off Rigidbody gravity
        MonsterRigidbody.useGravity = false;
        //is Die Off Collider
        MonsterCollider.enabled = false;
        //is Die Off NevMeshAgent
        pathFinder.Stop();

        Destroy(this.gameObject, DieTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("�浹");
    }
    private void OnTriggerStay(Collider other)
    {
        // �ڽ��� ������� �ʾ�����,
        // �ֱ� ���� �������� timeBetAttack �̻� �ð��� �����ٸ� ���� ����

        Debug.Log(other.gameObject.name);
        if (!dead && Time.time >= lastAttackTime + timeBetAttack)
        {
            Debug.Log("d1");
            // �������κ��� LivingEntity Ÿ���� �������� �õ�

                LivingEntity attackTarget = other.GetComponent<LivingEntity>();
                // ������ LivingEntity�� �ڽ��� ���� ����̶�� ���� ����
                if (attackTarget != null && attackTarget == targetEntity)
                {
                    // �ֱ� ���� �ð��� ����
                    lastAttackTime = Time.time;
                    Debug.Log("d2");

                    // ������ �ǰ� ��ġ�� �ǰ� ������ �ٻ����� ���
                    // Vector3 hitPoint = other.ClosestPoint(transform.position);
                    // Vector3 hitNormal = transform.position - other.transform.position;

                    // ���� ����
                    attackTarget.OnDamage(damage);
                }
                    
        }
    }
}
