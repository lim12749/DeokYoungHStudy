using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Survivor{
    public class PoolManager : MonoBehaviour
    {
        //������ ���� ����
        public GameObject[] Prefabs;
        //Ǯ��� ����Ʈ
        List<GameObject>[] Enemys;

        private void Awake()
        {
            Enemys = new List<GameObject>[Prefabs.Length];

            for (int index = 0; index < Enemys.Length; index++)
            {
                Enemys[index]= new List<GameObject> ();//�ʱ�ȭ
            }
        }
        public GameObject Get(int index)
        {
            GameObject select = null;
            
            foreach(GameObject item in Enemys[index])
            {
                if (!item.activeSelf)
                {
                    select = item;
                    select.SetActive(true);
                    break;
                }
            }
            if(!select)
            {
                select = Instantiate(Prefabs[index],transform);
                Enemys[index].Add(select);
            }
            return select;
        }
    }
}
