using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Ÿ���� ã��, ������ ���͸� ã�� �� ���̿��� ���� ���� �Ÿ��� ����� ���͸� ������ �� �ְ� �մϴ�.
/// </summary>
public class FindTargetFOV : MonoBehaviour
{
    [Header("Ŭ���� ��� ����")]
    public PlayerAnimator playerAnim; //���ݾִϸ��̼� ���� �ϱ� ����

    [Header("���� ����")]
    //������ : ��ü�� ����� �� ã�� ������ ũ�⸦ �����Ҷ� ���
    public float Redius; //Ž�� ����
    public GameObject AttackTarget; //ã������ ���
    public LayerMask targetMask; //�ĺ� �ϱ��� ���  ��Ʈ���� �� �ߵ� : 0001  + ȭ�� 0010 = 0011  
 
    public float FindTargetDelayTime;   //ã�½ð��� ������ �ΰ� Ž���ϰ� �մϴ�
    public float attackDelaySpeed; //���� �����ð�

    public List<Transform> visibleTargets = new List<Transform>();
    public Collider[] targetsInViewRadisu; //�ݶ��̴� �ȿ����� ����
    public float closet_dst;//�Ÿ�

    public GameObject ArrowObj; //ȭ��
    public Transform InstancePos; //ȭ�� ��ȯ ��ġ

    [Header("�� Ȯ�ο�")]
    public Vector3 doAttackAngle; //

    private void Start()
    {
        //�ڷ�ƾ ����� �����Ҷ� ����ϴ� �Լ�(������ �ڷ�ƾ �Լ��̸�)
        StartCoroutine(FindTargetDelay());
        
    }
    IEnumerator FindTargetDelay() //�Լ� �ڷ�ƾ
    {
        while (true)
        {
            //��� �纸�ϴ� �ð��� �ݴϴ� (�����ð�)
            yield return new WaitForSeconds(FindTargetDelayTime);
            FindTarget();
        }
    }
    public void FindTarget()
    {
        //���� ��ü�� ����ϴ�(�߽���, ������, �з����̾�)
        targetsInViewRadisu = Physics.OverlapSphere(transform.position, Redius, targetMask);

        closet_dst = Redius;//���� ����� �Ÿ� = ���� ����
        visibleTargets.Clear(); //�з��� ������ ����Ʈ�� �ֱ����� Ŭ���� ���ݴϴ�.
        GameObject cloeSet_target = null; //���� ����� ���͸� �־� ��
        int count = 0;//���� ��󸮽�Ʈ ī��Ʈ��

        //Ž���ѹ迭 ��ŭ �ݺ� ���ݴϴ�
        for(int i=0; i<targetsInViewRadisu.Length; i++)
        {
            //���� ���� �ű�� ����
            GameObject swapTarget = targetsInViewRadisu[i].gameObject;
            if (swapTarget.tag != "Monster")
                continue; //���� �δ콺 �Ǵ� �ٽ� �����϶�
            
            Transform target = swapTarget.transform;
            //Ÿ�ٰ� ���� �Ÿ� ������ �̾� ���ϴ�
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            // ���⿡���� ������� �Ÿ� ��(��ġ)
            float distanceToTarget = Vector3.Distance(transform.position, dirToTarget);

            //���� �������� �߻��մϴ�(��� ��ġ, ���� ��ġ, ������ ���̰�, out �浹ü ����)
            if(Physics.Raycast(transform.position,dirToTarget,distanceToTarget))
            {
                count++;
                visibleTargets.Add(target); //Ÿ���� ����Ʈ�� �־���
                doAttackAngle = dirToTarget;
                closet_dst = distanceToTarget;
                cloeSet_target = swapTarget; 
            }
        }
        if(count == 0)
        {
            AttackTarget = null; //���� ����� ����
        }
        else
        {
            AttackTarget = cloeSet_target; //���� ����� Ÿ���� ������Ʈ ���� ����
        }
    }
}
