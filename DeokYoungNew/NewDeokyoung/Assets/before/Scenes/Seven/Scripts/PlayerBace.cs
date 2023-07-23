using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �÷��̾��� �⺻�� �Ǵ� Ŭ������ �ʵ带 �ۼ��ϰ� �̸� ����մϴ�.
/// ���������� ����ϰ� �Ǵ°��� ����� �ڵ��� �ߺ��� �����ݴϴ�.
/// </summary>
namespace Seven{
    public enum PlayerType
    {
        None,SowrdMan,Archer,Mage
    }
    public class PlayerBace : MonoBehaviour
    {
        [SerializeField] PlayerType type;
        public int HP =0;
        public int Attack =0;

        protected PlayerBace(PlayerType _type)
        {
            this.type = _type;
        }
        public void SetInfo(int _hp, int _attack)
        {
            this.HP = _hp;
            this.Attack = _attack;
        }
        //�ܺο��� ȣ���Ҽ��ְ�
        public int GetHp() { return HP; }
        public int GetAttack() { return Attack; }

        public bool IsDead() { return HP <= 0; }
        public void OnDamage(int damage)
        {
            HP -= damage;
            if (HP < 0)
                HP = 0;
        }

    }
}
