using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAndFixedUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    /// <summary>
    /// ������Ʈ�� ����Ƽ���� ���� ���Ǵ� �Լ� �Դϴ�.
    /// �츮�� ������� ��� ��ũ��Ʈ���� �����Ӵ� �ѹ��� ȣ�� �˴ϴ�.
    /// �������� �����̳� ������ �ʿ��� ���� ������ ���
    /// ������Ʈ�� ������ Ÿ�Ӷ��ο� ���� ȣ����� �ʽ��ϴ�.
    /// � �������� ó�� �ð��� ���������Ӻ��� ��� 
    /// ������Ʈ ȣ�� ������ �ð��� �޶����ϴ�.
    /// </summary>
    {
        ///��� ������ ȣ��
        /// ������ ������Ʈ�� ���
        /// �� �������� ��ü �̵�
        /// ������ Ÿ�̸�
        /// �Է�
        Debug.Log("Update time :" + Time.deltaTime);
    }
    private void FixedUpdate()
        ///������ Ÿ�Ӷ��ο� ���� ȣ��
        ///ȣ������� �ð��� ����
        ///ȣ��� ���� �ʿ��� ��� ���� ����� �Ͼ�ϴ�
        ///������ٵ� ���� ������Ʈ�� ������ ��ġ�� ��Ҵ� fixed�� �ۼ��ؾ��մϴ�.
        ///fixed �������� ���� ��ũ������ �ϴ°�� �����ӿ� ������ ���� ����ϴ°��� �����ϴ�.
    {
        Debug.Log("FixedUpdate time :" + Time.deltaTime);
    }
}
