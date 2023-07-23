using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketballController : MonoBehaviour
{
public float MoveSpeed;

public Transform Ball; //�÷��̾�� �� ��ü�� ���ؼ� �˾ƾ��ϸ� �����մϴ�.
public Transform Arms; //��
public Transform PosOverHead;//������� ���� ��� ����
public Transform PosDibble; //���� �帮���ϴ� ����
public Transform Target;
public Transform Pivot;
public bool InBallInHands =true;

public float sin;
private bool IsBallFlying = false;

private float T;
private void Update()
{
    //walking 
    Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")); //�̵� ���� ����
    transform.position += direction * MoveSpeed * Time.deltaTime; // ����ġ = ����ġ+����*�ӵ�*�����Ӻ���
    transform.LookAt(transform.position + direction);//ĳ���Ͱ� �ȴ� ������ �ٶ󺸰� ȸ�������ݴϴ�.

    if(InBallInHands)
    {
        if(Input.GetKey(KeyCode.Space)) //�����µ���
        {
            Ball.position = PosOverHead.position; //���� ��ġ�� PosOverHad ��ġ��
            Arms.localEulerAngles = Vector3.right * 180; //x�� �������� 180���� ����

            //Look toward the target
            transform.LookAt(Pivot.position);
        }
        else
        {
            //�帮���� Ư¡�� ���� ���Ʒ��� Ƣ��µ� �ִ�. �����Ĵ� -1 0 1 �׷����� �׸��µ� ABS �� ���밪���� -������ ����������.
            Ball.position = PosDibble.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * sin)); //������ �ֱ⸦ ����� ���̴������� ���� ���;
            Arms.localEulerAngles = Vector3.right * 0;//x�� �������� 0���� ����
        }
    }
    //������
    if(Input.GetKeyUp(KeyCode.Space))
    {
        InBallInHands = false;
        IsBallFlying = true;
        T = 0;
    }
    //��������
    if(IsBallFlying)
    {
        T += Time.deltaTime;
        float duration = 0.5f;
        float t01 = T / duration;

        Vector3 aPoint =PosOverHead.position; //���� A��ġ���� b��ġ�� ������ 
        Vector3 bpoint = Target.position;
        Vector3 pos = Vector3.Lerp(aPoint, bpoint, t01); //���� ���ڷ� ���󰡴°��� �� �� �ִ�
        //���� ������ �������� �׸��µ� ���⼭�� �������� ����� �ϳ� ����غ���
        Vector3 arc = Vector3.up *5 * Mathf.Sin(t01* 3.14f); //a���⼭ �츮�� �����ĸ� �׸��� ���ϴ� ��� �׷����Ѵ�. ���� 0���� 1�� �� ���̸� ���ϸ�ȴ�.. ���� ���� ����. t01(�ð�) * pi

        Ball.position = pos + arc;

        //Momnet when ball
        if(t01 >= 1 ) //���� 1�̵Ǿ��� /��ǥ��ġ���������Ͽ���
        {
            IsBallFlying = false; //
            Ball.GetComponent<Rigidbody>().isKinematic = false;

        }
    }
}

private void OnTriggerEnter(Collider other)
{
    //���� �տ� ���� ���� ���� �ʴ°��
    if(!InBallInHands && !IsBallFlying)
    {
        InBallInHands = true;
        Ball.GetComponent<Rigidbody>().isKinematic = true;
    }
}
}
