using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : Monster
{
    public Yellow() : base(MonsterType.Far) //�Ұ�ȣ�� �����ڸ� ����.
    {
        Debug.Log($"�ڽ� ������ ȣ��");
    }
    public void Attack()
    {
        Debug.Log("����");
    }
}
