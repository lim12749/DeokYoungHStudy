using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Six
{
    public class SixInventory : MonoBehaviour
    {
        public class Stuff
        {
            public int projectileA;
            public int projectileB;
            public int projectileC;

            //Construector
            //�����ڸ� ����ϸ� ���α׷��Ӱ� �⺻���� �����ϰ� �ν��Ͻ�ȭ�� �����ϰ� �����ϸ� �б� ���� �ڵ带 �ۼ� �� �� �������ϴ�
            public Stuff() //�⺻ ������
            {
                projectileA = 1;
                projectileB = 1;
                projectileC = 1;
            }

        }

        public Stuff myStuff = new Stuff(); //create instance(an Object) 
        //Ŭ������ ������ ������ �ο��ϸ� Ŭ������ �̸��� ���� new ��� Ű���带 �����մϴ�. �׸��� �ٽ� Ŭ���� �̸��� ��� �մϴ�.
        //���� ()�� �����ڸ� ����Ѵٴ� �ǹ��Դϴ�. Ŭ������ ����ü�� �����ɶ�(�ν��Ͻ�) �ɶ� ���� �����ڰ� ȣ�� �˴ϴ�.

        //
        

        private void Start()
        {
            Debug.Log(myStuff.projectileA);
        }
    }
}
