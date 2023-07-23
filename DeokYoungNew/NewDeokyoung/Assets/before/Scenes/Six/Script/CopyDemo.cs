using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Six{ 
    public class SoftDepCopy{
        //field
        public int myField1; 
        public int myField2;
    
    }
    public class DeepCopyDemo{
        public int myField1;
        public int myField2;
        
        public DeepCopyDemo DeepCopy() //�޼ҵ� (Ŭ���� �Լ�)
        { //��ü�� ���� ���� �Ҵ��ؼ� �װ��� �ڽ��� �ɹ��� ������ ������ �־���մϴ�.

            DeepCopyDemo newCopy = new DeepCopyDemo(); //��ü instance ����
            newCopy.myField1 = this.myField1;
            newCopy.myField2 = this.myField2;

            return newCopy;
        }
    }
    public class CopyDemo : MonoBehaviour
    { 
        private void Start()
        {
            //soft
            { 
            SoftDepCopy source = new SoftDepCopy();//instance;   
            source.myField1 = 10; 
            source.myField2 = 20;

            SoftDepCopy target = source;
            target.myField2 = 30;

            Debug.Log($"Soft {source.myField1} {source.myField2}");
            Debug.Log($"Soft {target.myField1} {target.myField2}");
            } //�׷�ȭ ������������ �Ϻη� ���
            
            //deep
            {
                DeepCopyDemo source = new DeepCopyDemo();
                source.myField1 = 10;
                source.myField2 = 20;

                DeepCopyDemo target = source.DeepCopy();
                target.myField2 = 30;

                Debug.Log($"Deep {source.myField1} {source.myField2}");
                Debug.Log($"Deep {target.myField1} {target.myField2}");
            }
        }
    }   
}
