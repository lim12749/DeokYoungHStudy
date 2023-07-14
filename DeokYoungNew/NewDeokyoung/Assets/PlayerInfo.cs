using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ӽ����̽��� �ڵ带 �ۼ��� �ٸ� ����ڰ� �ڵ带 �и��ϰų� �ϳ��� ����� �׷�ȭ �Ҷ�����մϴ�. 
namespace Six { 
    //����
    public class GlobalScore
    {
        //���α׷� ��ü���� �ϳ��� ���� �ؾ��մϴ�.
        //��ü ���α׷����� �����ؾ��ϴ� ������ �ִٸ� �������� �ʵ带 ����ϴ°� �����ϴ�.
        //Static�� ���� Ŭ������ �ͼ� �˴ϴ�.
        public static int Score =0; //���� �ʵ���� ����(static) 
    }
    public class PlayerState
    {
        //�ʵ� �ۼ�
        public int HP;
        public int MP;
        public string PlayerName;

        //������ *�߿�
        //�⺻ ������
        public PlayerState(){// () ������ �ǹ� 
            HP = 100;
            MP = 100;
            PlayerName = "����";
        }
        public PlayerState(int _HP, int _MP, string _name) //������ ���� �����ִ°� �����ϴ�.
        {
            HP = _HP;
            MP = _MP;
            PlayerName = _name;
        }
       
        //�޼ҵ� �ۼ�
        public void ViewIINFO()
        {
            GlobalScore.Score++; //����

            Debug.Log($"{HP}, {MP}, {PlayerName}");
        }
    }

    public class playerDeepState
    {
        public int HP;
        public int MP;

        public playerDeepState DeepCopy() //�޼ҵ� (Ŭ���� �Լ�)
        {
            playerDeepState newCopy = new playerDeepState();
            newCopy.HP = this.HP;
            newCopy.MP = this.MP;
            return newCopy; //Ŭ���� Ÿ������ ������ ������� 
        }
    }

    public class PlayerInfo : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            PlayerState player0 = new PlayerState();
            player0.ViewIINFO();

            PlayerState player1 = new PlayerState(); //�ν��Ͻ�ȭ ��ü ����
            player1.HP = 100;
            player1.MP = 50;
            player1.PlayerName = "��_����";

            player1.ViewIINFO();//�޼ҵ带 ȣ���Ͽ� ����մϴ�.

            PlayerState player2 = new PlayerState(); //��ü ����
            player2.HP = 50;
            player2.MP = 100;
            player2.PlayerName = "��_����";
            player2.ViewIINFO();

            //������ ?����ĳ�� ����
            PlayerState Hero = new PlayerState(500, 500, "��������");
            Hero.ViewIINFO();

            Debug.Log($"{GlobalScore.Score}");

            //-----------------------------------------------------------------//
            //�������� ��������

            PlayerState SampleA = new PlayerState();
            SampleA.HP = 100;
            SampleA.MP = 200;

            PlayerState SampleB = SampleA;
            SampleB.MP = 500;

            Debug.Log($"{SampleA.HP} {SampleA.MP}"); // 100 200
            Debug.Log($"{SampleB.HP} {SampleB.MP}"); // 100 500


            //���� ���� ����
            playerDeepState SampleDA = new playerDeepState();
            SampleDA.HP = 100;
            SampleDA.MP = 200;

            playerDeepState SampleDB = SampleDA.DeepCopy(); 
            SampleDB.MP = 500;

            Debug.Log($"{SampleDA.HP} {SampleDA.MP}"); // 100 200
            Debug.Log($"{SampleDB.HP} {SampleDB.MP}"); // 100 500

        }
    }
}