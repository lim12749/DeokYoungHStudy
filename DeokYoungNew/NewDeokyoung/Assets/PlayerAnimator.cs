using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Vector3 velocity; //�ӵ�
    public bool isWork { get; set; }

    private Animator myAnimator; //�ִϸ����� Ŭ������ �����ɴϴ�

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        //����, �ڽĿ�����Ʈ�� Ŭ������ ����
        myAnimator = GetComponentInChildren<Animator>();
        isWork = false;

        //���� �ܺο� �ִ� Ŭ������ �����Ҷ� ���
        //var find = GameObject.Find("������Ʈ�̸�").GetComponent<Ŭ����>();
    }

    private void Update()
    {
        //�ִϸ��̼��� ���� �Ҷ� set�� ���� �����Ҷ� ���bool �Ķ���� Ÿ�� �Դϴ�.
        //"IsRun" �ִϸ��̼��� ��Ʈ���ϴ� �Ķ������ �̸��̰�
        //isWork�� ��Ʈ���ϴ� �����Դϴ�.
        myAnimator.SetBool("IsRun", isWork);
    }

    public void MoveMnetnimationSet(Vector3 _velocity)
    {
        velocity = _velocity; //�����̰� �ִ�
        isWork = velocity != Vector3.zero;
    }
    public void AttackAnimSet() //���� �ִϸ��̼� ����
    {
        myAnimator.SetTrigger("attack");
    }
    public void DieAnim() //�״� �ִϸ��̼� ����
    {
        myAnimator.SetTrigger("Die");
    }

}
