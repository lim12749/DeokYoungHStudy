using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{
    public float viewHP; //�� ������ ä�� Ȯ��


    protected override void OnEnable()
    {


    }
    public override void OnDamage(float _damage)
    {
        if(!Dead) //������� �������
        {
            Debug.Log("������ �ʾҰ� �������� �Խ��ϴ�.");
        }
        base.OnDamage(_damage); //����� ó�� ����

        viewHP = Health;
    }

    public void OnTriggerEnter(Collider other)
    {
        //�浹�� ������ �̺�Ʈ
    }
}
