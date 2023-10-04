using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : LivingEntity
{
    //�ӽ÷� ����� �� HP
    public Slider healthSlider; // ü���� ǥ���� UI �����̴� �Ӹ� ���� �۰� ���ΰ� �����ϴ� ������ ����� ����
    public Animator animator;
    public PLayerController playerMovecontroller;
    public FindTargetFOV playerFOV;
    public PlayerAnimator playerAnimator;
    protected override void OnEnable()
    {
        base.OnEnable();    // LivingEntity�� OnEnable() ���� (���� �ʱ�ȭ)

        healthSlider.gameObject.SetActive(true); //������ ���۵Ǹ� Ȱ��ȭ �մϴ�

        healthSlider.maxValue = StartingHealth; //���� ü���� �ִ�ä������ ����

        healthSlider.value = Health; //���� ü���� base���� ������ �ʱ� ä������ ������

        //�����ϼ��ְ��ϴ� key
        playerMovecontroller.enabled = true;
        playerFOV.enabled = true;
        // �÷��̾� ������ �޴� ������Ʈ�� Ȱ��ȭ
        //playerMovement.enabled = true; //���߿� �װų� ���� ���������� ���� ����մϴ�
        //playerShooter.enabled = true;
    }

    //OnDamage�� ���̳� ���� ������ ������� ü���� ���ҽ�Ű�� �޼ҵ� �Դϴ�.
    public override void OnDamage(float _damage)
    {
        if(!Dead) //������� ������� ȿ���� ���
        {
            Debug.Log("������ �ʾҰ� �������� �Խ��ϴ�.");
        }
        //����� ó�� ����
        //ä���� Living�� ü���� �ְ� �̰��� ����Ͽ� ������ ��
        base.OnDamage(_damage);

        //ü���� ���������� �����̴��� �ð������� �������� ü�µ� ����
        healthSlider.value = Health;
    }
    public override void Die()
    {
        base.Die(); //LivingEntity Die�Լ� ���� 

        // ü�� �����̴� ��Ȱ��ȭ �׾����� �ٸ� ������ ���ϰ� ���� �뵵
        healthSlider.gameObject.SetActive(false);

        //��� �ִϸ��̼� ���
        //animator.SetTrigger("death");
         
        //����ϸ� �ݶ��̴� �� ���� ���ϰ� �ؾ���
        playerMovecontroller.enabled = false;
        playerFOV.enabled = false;
        //playerAnimator.enabled = false;


    }
    public void OnTriggerEnter(Collider other)
    {
        //�浹�� ������ �̺�Ʈ �����۸Ծ����� ���
    }
}
