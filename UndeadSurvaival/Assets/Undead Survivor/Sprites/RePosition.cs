using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor{
    public class RePosition : MonoBehaviour
    {
        Collider2D colls;
        private void Awake()
        {
            colls = GetComponent<Collider2D>();
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag("Area"))
                return;

            Debug.Log("�ǳ�?");
            Vector3 playerPosition = GameManager.instace.player.transform.position;
            Vector3 myPosition = transform.position;
            //���밪�� �ٿ� ����� ����
            float diffX = Mathf.Abs(playerPosition.x - myPosition.x);
            float diffY = Mathf.Abs(playerPosition.y - myPosition.y);

            Vector3 playerdir = GameManager.instace.player.inputVec;
            //3�� ���� (����) ? (��) : (����)
            float dirX = playerdir.x < 0 ? -1 : 1;
            float dirY = playerdir.y < 0 ? -1 : 1;

            switch(transform.tag)
            {
                case "Ground":
                    //������� x�� ��ū���
                    if (diffX > diffY)
                        //��ĭ�� �پ 40��
                        transform.Translate(Vector3.right * dirX * 40);
                    else if (diffX < diffY)
                        transform.Translate(Vector3.up * dirY * 40);
                    break;
                case "Enemy":
                    if (colls.enabled)
                    {
                        //�÷��̾��� �̵���������� ���� �������� �����ϵ��� �̵�
                        transform.Translate(playerdir * 20+new Vector3(Random.Range(-3f,3f), Random.Range(-3f, 3f),0f));
                    }
                    break;
            }
        }
    }
}
