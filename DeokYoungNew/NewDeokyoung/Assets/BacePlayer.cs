using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[����������] [������ Ÿ��] [Ŭ������]
public class AnimalClassDemo
{
    public string Name; //�ʵ�(an Ŭ���� ����)
    public string Color; 
}

public class BacePlayer : MonoBehaviour
{
    //�̵�, ����, ����, ȸ��, ��ȣ�ۿ�, �뽬, 
    //���ϴ� ����� ���� �и��ؼ� ��
    private void Start()
    {
        //Ŭ������ ����ϴ� ����
        //[Ÿ��] [������] = [new] [Ÿ��()] new Ŭ����Ÿ��() ->������
        AnimalClassDemo animal = new AnimalClassDemo(); //�ν��Ͻ� = ��ü
        //�ν��Ͻ��� ���� �ֳ� 
        // �����Ǽ� ���Ǵ°͵� �Ѿ�, �����, ��.
        animal.Name = "�����";
        animal.Color = "ġ��";

        Debug.Log($"{animal.Name}{animal.Color}");
       
    }

}
