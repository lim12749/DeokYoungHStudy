using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchDemo : MonoBehaviour
{
    public int intelliogentce = 5;



    void Greet()
    {
        switch (intelliogentce)
        {
            case 5:
                print("Why hello there good sir! Let me teach you about Trigonomertry");
                break; //������ case�ڿ� ���� �ڵ带 ���� �����ϰ� �����մϴ�.
            case 4:
                print("�ȳ� ���� ���̾�");
                break; 
            case 3:
                print("����");
                break; 
            case 2:
                print("Grog Smash!");
                break; 
            case 1:
                print("����...");
                break;

            default: //if else ���� else�� ����մϴ� ����Ȳ�� �����ϰԵ˴ϴ�.
                break;
        }
    }
}
