using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seven{
    public class SowrdMan : PlayerBace
    {
        //�⺻ ���� Ŭ������ ��ü�� �����Ҷ� ������ ���ÿ� �θ� �ִ� �����ڸ� ���� Ŭ������ �ʱ�ȭ �ϰ� ���� �մϴ�.
        //�����ڴ� Ŭ���� �̸��̶� ���� ������ ������ ������
        public SowrdMan() : base(PlayerType.SowrdMan) //�����ڿ��� �θ������ ȣ��
        {
            //type = PlayerType.SowrdMan; //�츮�� �̷��� ���� �÷��̾ ����� ������ ���� �� ����
            SetInfo(100, 10);   
        }
        public void Attak()
        {
            Debug.Log("����!");
        }
        public void Move()
        {
            Debug.Log("�̵�!");
        }

        //��ų ������ ���� ����
    }
}
