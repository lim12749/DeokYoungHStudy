using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public class Stuff{ // �ϳ��� Ʋ�� ���� ����ϱ����� ����
        public int bullets;
        
        public Stuff(){ } //�⺻ ������
        public Stuff(int _bul) //������ 
        {
            bullets = _bul;
        }
    }
    public Stuff mystuff = new Stuff(10); //�ν��Ͻ�ȭ

    //�ʵ�
    public float speed; //�յ��¿� �����̴°� 
    public float turnSpeed; //ȸ���ϴ� �ӵ���

    //���� Ÿ���� ��Ȯ�� ����� ������� Ŭ���� �̸��� �ڷ������� �ҷ��� ����մϴ�.
    public Rigidbody bulletPrefab; //�ν��Ͻ�ȭ ��ų ���� ���� 
    public Transform firePos; //�߻��� ��ġ

    private void Update()
    {
        Movement();
        Shoot();
    }
    void Movement() //������
    {
        //������ �Է��ϴ� ���� ��� ���ϴ�.
        float forwardMovemnet = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turnMovement = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        //�̵� ��� ����
        transform.Translate(Vector3.forward * forwardMovemnet);
        //ȸ�� ��� ����
        transform.Rotate(Vector3.up * turnMovement);

    }
    void Shoot() //�߻�
    {
        //���콺 �Է�
        if(Input.GetButtonDown("Fire1") && mystuff.bullets >0)
        {
            Rigidbody bulletInstace = Instantiate(bulletPrefab, firePos.position, firePos.rotation) as Rigidbody;
            bulletInstace.AddForce(firePos.forward * 1000);
            //
            mystuff.bullets--;

        }
    }
}
