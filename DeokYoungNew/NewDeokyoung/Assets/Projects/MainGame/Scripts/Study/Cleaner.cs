using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //�׼� ���� �ʿ�
/// <summary>
/// Action ���ο�
/// Event Action �׼� Ÿ���� �Է°� ����� ���� �޼��带 ����ų �� �ִ� ��������Ʈ �̺��. 
/// ��������Ʈ�� �븮�ڷ� �����Ǹ� �޼��带 ������ �Ҵ� ���� �� �ִ� Ÿ�� �Դϴ�.
/// Action Ÿ���� �������� void Sample() ó�� �Է°� ����� ���� �޼��带 ����� �� �ֽ��ϴ�.
/// ��ϵ� �޼���� ���ϴ� ������ �Ź� ������ �� �ֽ��ϴ�.
/// �Ʒ����ø� ���ڽ��ϴ�.
/// </summary>
public class Cleaner : MonoBehaviour
{
    Action OnClean; //�׼� ����

    void Start()
    {
        OnClean += CleaningroomA;
        OnClean += CleaningroomB;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnClean();
        }
    }
    private void CleaningroomB()
    {
        Debug.Log("A�� û��");
      
    }

    private void CleaningroomA()
    {
        Debug.Log("B�� û��");
       
    }
}
