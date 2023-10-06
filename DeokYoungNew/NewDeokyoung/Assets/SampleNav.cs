using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleNav : MonoBehaviour
{
    //Ai�� �����ϴ� ������ ��ġ
    public Transform Destination;
    //��Ŭ������ ������ �ִ� ������Ʈ�� NavMeshAgent�� �����;��մϴ�.
    public NavMeshAgent myNavmeshAgent;

    public Rigidbody rb;
    public RaycastHit hit;

    private void Start() 
    {
        //��� �����ɴϴ�.
        myNavmeshAgent = GetComponent<NavMeshAgent>();
        // Target�̶�� �̸��� ������Ʈ�� ã�� ������Ʈ�� ������ �ִ� Transfrom�� ����� �����ɴϴ�
        //Destination = GameObject.Find("Target").GetComponent<Transform  >();

    }
    private void Update()
    {
        //�������� �����մϴ�.(Ÿ�� ��ġ)
        //myNavmeshAgent.SetDestination(Destination.position);

        //���콺 �����ͷ� ���� ���
        if(Input.GetMouseButtonDown(0)) //Ŭ���ϴ� ��� ����
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

            if(Physics.Raycast(ray, out  hit, Mathf.Infinity))
            {
                //transform.position = hit.point;

                myNavmeshAgent.SetDestination(hit.point);
                //myNavmeshAgent.stop
            }
        }
    }

}
