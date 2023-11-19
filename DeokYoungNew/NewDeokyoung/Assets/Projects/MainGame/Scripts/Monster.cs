using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
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

    public bool isMove = false;
    public bool isRun = false;

    [SerializeField] private LivingEntity targetEntity; // ������ ���
    public LayerMask whatIsTarget; // ���� ��� ���̾�


    public float radius;
    public Collider[] col;
    private bool hasTarget
    {
        get
        {
            if(targetEntity !=null && !targetEntity.Dead)
            {
                return true;
            }
            return false;
        }
    }

    [Header("Attack Pramiter")]
    public float damage = 20f; // ���ݷ�
    public float timeBetAttack = 0.5f; // ���� ����
    private float lastAttackTime; // ������ ���� ����
    private void Awake()
    {
        pathFinder = GetComponent<NavMeshAgent>(); 
        MonsterAnim = GetComponent<Animator>();

        
    }
    public void SetUp(float newHP,float newDamage,float newSpeed)
    {
        StartingHealth = newHP;
        Health = StartingHealth;

        damage = newDamage;

        pathFinder.speed = newSpeed;


    }
    private void Start()
    {
        // ���� ������Ʈ Ȱ��ȭ�� ���ÿ� AI�� ���� ��ƾ ����
        StartCoroutine(UpdatePath());
    }
    private void Update()
    {
        /*
        //��ǥ ã�°� ������Ʈ �ؾ��մϴ� 
       // pathFinder.SetDestination(Target.transform.position);
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
        }*/
    }
    private IEnumerator UpdatePath()
    {
        //���Ͱ� ����ִ� ��� ���ѷ����� �����ϴ�.
        while(!Dead)
        {
            if(hasTarget)
            {
                //Debug.Log("?");
                //��������� ���� : ��θ� �����ϰ� AI �̵��� ��� ����
                pathFinder.isStopped = false;
                pathFinder.SetDestination(targetEntity.transform.position);
            }
            else //��������� ������
            {

                //Ai�� �̵� ���� ��ŵ�ϴ�.
                pathFinder.isStopped = true;

                //20������ �������� ���� ������ ���� �׷�����, ���� ��ġ�� ��� �ݶ��̴��� �����ɴϴ�.
                //��, whatIsTarget ���̾ ���� �ݶ��̴��� ���������� ���͸� �մϴ�.
                //�߽�, ������ , ���̾� ����
                 col = Physics.OverlapSphere(transform.position, radius,whatIsTarget);

                for(int i=0; i< col.Length;i++)
                {
                    var livingEntity = col[i].GetComponent<LivingEntity>(); //������Ʈ ��� �����ͼ� ���⿡ ���

                    //Living ������Ʈ�� �����ϰ� �ش� Living�� ����ִ��� üũ
                    if (livingEntity != null && !livingEntity.Dead)
                    {
                        //��������� �ش� livingEntity�� ����
                        targetEntity = livingEntity;

                        //for���� ��� ����
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(0.25f); //0.25�ʾ� �����ϰ� ���ѹݺ��� �����ϴ�.
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


    public override void OnDamage(float damage)
    {
        //is not Dead
        if(!Dead)
        {
            Debug.Log("���� �ǰ� ");
        }
        base.OnDamage(damage);
    }
    public override void Die()
    {
        base.Die();

        //is Die play Animator
        MonsterAnim.SetTrigger("IsDie");
        //is Die Off Rigidbody gravity
        MonsterRigidbody.useGravity = false;
        //is Die Off Collider
        MonsterCollider.enabled = false;
        //is Die Off NevMeshAgent
        pathFinder.isStopped = true;
        pathFinder.enabled = false;

        Dead = true;
        //Destroy(this.gameObject, DieTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("�浹");
    }
    private void OnTriggerStay(Collider other)
    {
        // �ڽ��� ������� �ʾ�����,
        // �ֱ� ���� �������� timeBetAttack �̻� �ð��� �����ٸ� ���� ����

        //Debug.Log(other.gameObject.name);
        if (!Dead && Time.time >= lastAttackTime + timeBetAttack)
        {
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
