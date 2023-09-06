using UnityEngine;
using System; //�̺�Ʈ ���
/// <summary>
/// Player Monster share
/// </summary>
public class LivingEntity : MonoBehaviour
{

    public float StartingHealth = 100f; //Setting Valuse

    //Auto-implemented properties 
    public float Health { get; protected set; } //Now Hp Value

    public bool Dead { get; protected set; } //Now Living

    //��������Ʈ :  �Է°� ����� ���� �޼��带 ����ų�� �ִ�.
    //��ϵ� �޼���� ���ϴ� ������ �Ź� ���� �� �� �ִ�.
    public event Action OnDeath; // ����� �ߵ��� �̺�Ʈ

    //�÷��̽� �θ� Ŭ�������� ���� OnEnable�� ����˴ϴ�
    //Start �Լ� ������ ȣ��˴ϴ�. ���� �÷��� �Ǵ� ���½� �ѹ� �����մϴ�
    //SetActive�ε� Ȱ��ȭ �˴ϴ�,  ����ü�� Ȱ��ȭ�ɶ� ���¸� ����
    protected virtual void OnEnable()
    {
        Dead = false; //����, ��Ƴ��� ���¸� ���� �������� ����

        Health = StartingHealth; //���� ü������ �̴ϼȶ�����!(�ʱ�ȭ)
    }
    //�������� �����ϴ� �Լ�
    public virtual void OnDamage(float damage )
    {
        Health -= damage; // ������ ����

        if(Health<=0 &&!Dead)
        {
            Die(); //��� ó�� �Լ� ����
        }
    }
    // ü���� ȸ���ϴ� ���
    public virtual void RestoreHealth(float newHealth)
    {
        if (Dead)
        {
            // �̹� ����� ��� ü���� ȸ���� �� ����
            return;
        }

        // ü�� �߰�
        Health += newHealth;
    }
    // ��� ó��
    public virtual void Die()
    {
        // onDeath �̺�Ʈ�� ��ϵ� �޼��尡 �ִٸ� ����
        if (OnDeath != null)
        {
            OnDeath(); //�Լ��� ����صΰ� �ϰ������� ���� �մϴ�
        }

        // ��� ���¸� ������ ����
        Dead = true;
    }
}
