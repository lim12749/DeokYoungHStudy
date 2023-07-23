using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoComponent : MonoBehaviour
{
    Rigidbody rb; //���� ����� ���� ������Ʈ ����!! ����ó�� ������ �Ͽ����� ��밡����

    void Start()
    {
        //������ ���۵ɶ� �ʱ�ȭ ���������� ������Ʈ ���� ��������� ��ħ
        //������ �Ҷ� ������ ����� �����ͼ� ���۽�ų������ ��Ȯ�ϰ� �������ϰ� ������ �ؾ��մϴ�.
        rb = gameObject.transform.GetComponent<Rigidbody>(); //�� Ŭ������ �������ִ� ���� ������Ʈ�� ������Ʈ�� �����մϴ�.

        rb.isKinematic = false;// .�����ڸ� ���� �Ʒ��ִ� ������Ƽ, �Լ��� ����� Ȯ���ϰ� ��� �� �� �ֽ��ϴ�.

        //���� ������Ʈ�� ���°��
        GameObject a = transform.gameObject; //�߰��� ���ӿ�����Ʈ �����̳ʸ� �����ϰ�
        a.AddComponent<Joint>();  //AddComponet<�߰��� ���>(); ����Ͽ� �߰����ݴϴ�.
    }
}
