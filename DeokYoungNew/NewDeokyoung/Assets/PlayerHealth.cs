using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{
    public float viewHP; //�� ������ ä�� Ȯ��
    [Header("Audio")]
    public AudioClip deathCilp; //��� �Ҹ�
    public AudioClip hitClip;

    private AudioSource playerAudioPlayer;

    [SerializeField] private PLayerController pLayerController;//�÷��̾ �����̴� Ŭ����
    [SerializeField] private FindTargetFOV fOV; //�÷��̾��� ���� ���
    [SerializeField] private PlayerAnimator Playeranim;

    private void Awake()
    {
        //as
        pLayerController = GetComponent<PLayerController>();
        //Fov�� �ڽ��̴ϱ� ��������
        Playeranim = GetComponent<PlayerAnimator>();
    }
    protected override void OnEnable()
    {
        base.OnEnable(); //livingEntity�� OnEnable()�� �����ϰ� ���¸� �ʱ�ȭ��

        viewHP = Health;

        //���� ������Ʈ Ȱ��ȭ
        pLayerController.enabled = true;
        Playeranim.enabled = true;
    }
    public override void OnDamage(float _damage)
    {
        if(!Dead) //������� �������
        {
            Debug.Log("������ �ʾҰ� �������� �Խ��ϴ�.");
        }
        base.OnDamage(_damage); //����� ó�� ����

        viewHP = Health;
    }
    public override void Die()
    {
        base.Die();//���ó�� ����

        //����� �Ҹ��� ü�� ��Ȱ��ȭ�� ����

        Playeranim.DieAnim(); //������ �ִϸ��̼� ����

        pLayerController.enabled = false;
        Playeranim.enabled = false; 
    }
    public void OnTriggerEnter(Collider other)
    {
        //�浹�� ������ �̺�Ʈ
    }
}
