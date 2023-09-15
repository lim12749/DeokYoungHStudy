using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ��ũ��Ʈ�� ���� ������Ʈ�� ����Ű, wasdŰ�� �̿��Ͽ� ������ǥ���� ������ �� �ֽ��ϴ�.
/// </summary>
public class PlayerController : MonoBehaviour
{
    //���� ����
    private Vector3 viewForward; //���� ����
    private Vector3 viewRight; //������ ����
    private Vector3 direction; //���� ����

    //ĳ���� �����̱����� Ŭ����
    private CharacterController myCharacterController;
    //ĳ���� �ִϸ��̼��� ��Ʈ���ϱ����� Ŭ����
    private PlayerAnimator myPlayerAnim; //�ִϸ��̼� ������ ���� Ŭ����
    [Header("Setteing")] //�ν����ͺ信 Ÿ��Ʋ
    public float moveSpeed; //�÷��̾� �̵��ӵ�
    private void Awake() //������ ���������� ���ѹ� ȣ��
    {
        Init(); //������ �������ڸ��� �ʱ�ȭ ������Ѵ�
    }
    private void Init() //�ʱ�ȭ�� ���� �Լ�
    {
        //���� ����
        //ī�޶� �����ִ� ������ ���������� ����
        viewForward = Camera.main.transform.forward;
        viewForward.y = 0f; //���̰� ������ �ȵ˴ϴ�.
        //���� ������ ���� 1�� ����� �ݴϴ�.
        viewForward = Vector3.Normalize(viewForward);
        //Quaternion�� �� ���Ͱ� ������ �ȳ��� �ϱ�����
        //��������� �������� ������
        viewRight = Quaternion.Euler(new Vector3(0, 90, 0)) * viewForward;

        //������Ʈ �߰�
        //getComponet�� �� Ŭ������ ����ϴ°��� ���� �־���մϴ�.
        myCharacterController = GetComponent<CharacterController>();
        myPlayerAnim = GetComponent<PlayerAnimator>(); 
    }

    //������ ���� ���� �ܼ� ��
    private void Update()
    {
        PlayerMovement();
    }
    //������ ���� �����
    private void FixedUpdate() 
    {
        
    }
    private void PlayerMovement() // Movemnet , Locomotion 
    {
        //������ Ű�� �Է¹޴� ���� ����
        Vector3 rightMove = viewRight * Input.GetAxis("Horizontal"); //����
        //���� Ű�� �Է¹ٴ� ���� ����
        Vector3 forwardMove = viewForward * Input.GetAxis("Vertical"); //����
        //�Է�Ű�� �޴� ���� ��������
        Vector3 finalMovement = forwardMove + rightMove;
        //�̵������� ���������� 1�� ����� �ݴϴ�.
        direction = Vector3.Normalize(finalMovement); //

        myPlayerAnim.MoveMnetnimationSet(direction); //�ִϸ��̼� ����������

        //�����̳�? 
        if(direction != Vector3.zero)
        {
            //�÷��̾� ����������� �����̰��ϱ�
            transform.forward = direction; //���� ����
            //ĳ������Ʈ�ѷ��� �̿��ؼ� �����̰� �ϱ�
            myCharacterController.Move(direction * moveSpeed* Time.deltaTime);

        }
    }

    
}
