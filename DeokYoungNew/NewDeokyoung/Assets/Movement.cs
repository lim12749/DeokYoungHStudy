using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    //�ʵ�
    public float speed; //�յ��¿� �����̴°� 
    public float turnSpeed; //ȸ���ϴ� �ӵ���

    // Update is called once per frame
    void Update()
    {
        Movements();
    }
    void Movements() //������
    {
        //������ �Է��ϴ� ���� ��� ���ϴ�.
        float forwardMovemnet = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turnMovement = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        //�̵� ��� ����
        transform.Translate(Vector3.forward * forwardMovemnet);
        //ȸ�� ��� ����
        transform.Rotate(Vector3.up * turnMovement);

    }
}
