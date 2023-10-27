using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float ArrowSpeed;
    public Transform SpwanPos;
    public Transform Target;
    private Vector3 dir;

    public float ArrowDamage = 10f;
    private float T;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Monster"))
        {
            var targetDamage = other.GetComponent<Monster>();
            //targetDamage.SetDamage((int)ArrowDamage);
            targetDamage.OnDamage(ArrowDamage);
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        ArrowLocomotion(); //Arrow MoveFnc
        //ArrowForwadLocomotion();
    }
 
    //move to direction init
    public void SetLocomotion(Transform _target, Transform spwanPos)
    {
        SpwanPos = spwanPos;
        Target = _target;
    }
    private void ArrowLocomotion()
    {   
        //������
        T += Time.deltaTime;
        float duration = 0.5f;
        float t01 = T / duration;
        Vector3 aPoint = SpwanPos.position; //���� A��ġ���� b��ġ�� ������ 
        Vector3 bpoint = Target.position;
        Vector3 pos = Vector3.Lerp(aPoint, bpoint, t01); //���� ���ڷ� ���󰡴°��� �� �� �ִ�

        Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f); //a���⼭ �츮�� �����ĸ� �׸��� ���ϴ� ��� �׷����Ѵ�. ���� 0���� 1�� �� ���̸� ���ϸ�ȴ�.. ���� ���� ����. t01(�ð�) * pi

        transform.position = pos + arc;

   
    }
    private void ArrowForwadLocomotion()
    {
        //�Ʒ� �ڵ�� ��� ������
        //�������� ��� ����
        //transform.Translate(Vector3.forward * Time.deltaTime);
        
        dir = Target.position- transform.position; //������� ��ǥ - ����ġ = ��ǥ����
        dir.Normalize();

        transform.position += dir *ArrowSpeed* Time.deltaTime;
       
        //transform.LookAt(Target);
    }
}
