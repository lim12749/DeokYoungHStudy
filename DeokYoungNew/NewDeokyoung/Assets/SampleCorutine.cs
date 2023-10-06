using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCorutine : MonoBehaviour
{
    public Transform[] target; //�迭�� �������� ������ �Ӵϴ�

    private void Start()
    {
        //�ڷ�ƾ ����
        StartCoroutine(FncName());
    }
    private void Update()
    {
        naem();
        //FncName();
    }
    //�޼ҵ� ���� ���
    private void naem()
    {
        Debug.Log("�Լ� ����");
    }
    private IEnumerator FncName()
    {
        int index= 0;
        while(true)
        {
            //����ġ�� ������ ��ġ���� ������ �ݴϴ�.
           transform.position =  Vector3.MoveTowards(transform.position, target[index].position, 10*Time.deltaTime);
            
            //�����߳� ������ ����
            if(Vector3.Distance(transform.position, target[index].position)<0.1f)
            {
                //���������� target�� ����
                index++;
                if(index>=target.Length)
                {
                    index = 0;
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
