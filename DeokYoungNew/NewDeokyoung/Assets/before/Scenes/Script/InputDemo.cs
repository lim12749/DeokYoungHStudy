using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //�ؽ�Ʈ�� �����ϴ� ���̺귯�� �߰��մϴ�.

public enum KeyType { None, GetKey, GetButton, GetAxis, Mouse}
public class InputDemo : MonoBehaviour
{
    public Rigidbody myRb; //���������� ����ϴ� ��� �߰�
    public KeyType keyType = KeyType.None; //ŰŸ���� ���������� �и��ؼ� �����Ϸ��� �����
    public TextMeshProUGUI InputValuse; //�Է°��� �ؽ�ƮUI�� ���̰� �Ϸ��� ���
    public TextMeshProUGUI InputValuse2; //�Է°��� �ؽ�ƮUI�� ���̰� �Ϸ��� ���
    public float range; //���� ����

    private void Start() //ó�� �����Ҷ� �ʱ�ȭ ���ִ� �޼ҵ� 
    {
        //����� �����ͼ� ����� �غ� ���ݴϴ�.
        myRb = GetComponent<Rigidbody>();
    }
    //FixedUPdate�� ������ ȣ�� ������ �����Ͽ� ���������� �� �̵� �Ǵ� ������ ���� ��꿡 ���Ǵ� Update�Դϴ�.
    private void FixedUpdate()
    {
        //Ű���常 �Է� �������ֽ��ϴ�.
        bool _down = Input.GetKeyDown(KeyCode.Space); //��ư��
        bool _Up = Input.GetKeyUp(KeyCode.Space);
        bool _Hold = Input.GetKey(KeyCode.Space);

        //Ű����� ���̽�ƽ���� �Է� ������ �ֽ��ϴ�.
        bool _bDown = Input.GetButtonDown("Jump");
        bool _bUp = Input.GetButtonUp("Jump");
        bool _bHold = Input.GetButton("Jump"); //��ư��

        float h = Input.GetAxis("Horizontal"); //���� �̿��ϴ� Ű ����
        float v = Input.GetAxisRaw("Vertical"); //����
        float xPos = h * range; //Ű �Է°� * ������ ������
        float vPos = v * range; 

        //�ý�Ʈ������ +������ �̿��Ͽ� ������ ����� �ִ�
        InputValuse.text = "Value " + h.ToString("F2");
        InputValuse2.text = "Value" + v.ToString("F2");

        switch (keyType)
        {
            case KeyType.None:
                break;
            case KeyType.GetKey:
                if(_down)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_down);
                }
                else if(_Hold)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_Hold);
                }
                else if(_Up)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_Hold);
                }
                
                break;
            case KeyType.GetButton:
                if (_bDown)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_bDown);
                }
                else if (_bHold)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_bHold);
                }
                else if (_bUp)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_bUp);
                }
                break;
            case KeyType.GetAxis:
                //�� ��ġ�� = ���ο� vector3����(�¿�, ����, �յ�)
                transform.position = transform.position+ new Vector3(xPos, 3f, vPos); 
                break;
            case KeyType.Mouse:
                break;
            default:
                break;

        }
    }
}
