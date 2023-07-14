using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MonsterType { None = 0, Almost =1, Far = 2 }
public class Monster : MonoBehaviour //Base / �θ� Ŭ����
{
    //���м� ? ������ ������� �ʰ� �����ָ鼭 �츮�� ����Ҽ� �ְ� ��������.
    //  private      protected        public
    public MonsterType monsterType; //������ ������ ����
    private int Hp; //������ �� Ŭ������ ������ ���ϰ� ����
    private int Attack; //��ӹ��� Ŭ���������� ������ ����
    //������Ƽ
    //public int MP { get; set; } //�ڵ����� ������Ƽ
    private int TotalMP; //���� ����Ǵ� ��
    public int ViewMP //�ٸ������� ����Ҷ� �������� ���� 
    {
        get //getter�� ���� �����Ҷ�
        {
            return TotalMP;
        }
        set //���� �Ҵ��Ҷ�
        {
            TotalMP = value; //valuse �� �ܺο��� ������ ���� ����
        }
    }
   

    //������ ( �����ڴ� Ŭ������ �ν��Ͻ�ȭ ������ ȣ�� )
    public Monster(MonsterType type)
    {
        monsterType = type;
        Debug.Log("���̽� Ŭ����");
    }
    public void SetInfo(int _hp, int _attack) //�ܺο��� ���� �����Ҷ� ����� �޼ҵ�
    {
        this.Hp = _hp; //this Ű����� �� �ڽ��� ����ŵ�ϴ�.
        this.Attack = _attack;
    }
    //�������� ����� ��Ӻκп��� ����ϴ�.
    public int GetHP() { return Hp; }  
    public int GetAttack() { return Attack; }
    public bool IsDie() { return Hp <= 0; }
    public void IsDamage(int _damage)
    {
        Hp = Hp - _damage; 
        if (Hp < 0)
            Hp = 0;
    }
    public Monster()  //�⺻ ������
    {
        Debug.Log("Base �⺻ ������ ȣ��");
    }
}
//��� ���� Ŭ���� ���� : [Ŭ�����̸�]
public class Ghost : Monster // ����� ���� / �ڽ� Ŭ���� / chaild / �Ļ�Ŭ����
{
    //������ ����
    //��ų ����
    //��� ����
    public Ghost() : base(MonsterType.Almost) //�Ұ�ȣ�� �����ڸ� ����.
    {
        Debug.Log($"�ڽ� ������ ȣ��");
    }
    public void AttackGhost()
    {
        Debug.Log("��Ʈ �����մϴ�");
    }
    public void Move()
    {
        Debug.Log("��Ʈ �����Դϴ�.");
    }
}
