using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Like{
    public class Player : MonoBehaviour
    {
        public float Speed;
        private Rigidbody myRigidbody;
        private PlayerInputManager inputManager;

        private void Awake()
        {
            myRigidbody = GetComponent<Rigidbody>();
            inputManager = GetComponent<PlayerInputManager>();
        }
        private void FixedUpdate()
        {
            UpdateMove();
        }
        private void UpdateMove()
        {
            //�����ش�
            //myRigidbody.AddForce(inputManager.InputVector);

            //�ӵ� ����
            //myRigidbody.velocity = inputManager.InputVector;

            //��ġ �̵�   vector 1�θ���� �ӵ� ���� ������Ʈ������ ����ϴ� ��ŸŸ��
            Vector3 nomal = inputManager.InputVector.normalized * Speed *Time.fixedDeltaTime; 
            myRigidbody.MovePosition(myRigidbody.position+ nomal);

        }
    }
}
