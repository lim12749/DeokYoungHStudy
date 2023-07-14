using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Create : MonoBehaviour
{
    //�ν��Ͻ�ȭ ��ü �ʿ�
    public Ghost PlayerModel; //������ �� ���� 
    public Yellow YellowModel;

    public void CreatePlayer()
    { 
        Debug.Log("Player ����");
                           //ĳ���� ���� , �����ϴ� ����Դϴ�.
        //������ ������Ʈ�� ���� ��Ʈ���ϱ� ���� ������ ������ �մϴ�.
        GameObject _ghost = Instantiate(PlayerModel.gameObject);
        //���� �����ϱ����� Ŭ������ ������ ���ݴϴ�.
        Ghost _val = _ghost.GetComponent<Ghost>();  
        _val.SetInfo(500, 50); //��Ʈ Ŭ������ �����ؼ� �޼ҵ� ȣ��
        _val.ViewMP = 100; //set�� ���� ���� �Ҵ��� �˴ϴ�.
        Debug.Log($"{_val.ViewMP}");
        // _val.GetHP
       //_val.GetAttack
    }
    public void CreatePlayerTwo()
    {
        //������ ������Ʈ�� ���� ��Ʈ���ϱ� ���� ������ ������ �մϴ�.
        GameObject _Yellow = Instantiate(YellowModel.gameObject);
        //���� �����ϱ����� Ŭ������ ������ ���ݴϴ�.
        Yellow _val = _Yellow.GetComponent<Yellow>();
        _val.SetInfo(100, 600); //��Ʈ Ŭ������ �����ؼ� �޼ҵ� ȣ��
        _val.ViewMP = 100; //set�� ���� ���� �Ҵ��� �˴ϴ�.
        Debug.Log($"{_val.ViewMP}");
    }
}
