using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == Tag.JIAOHU)
        {
            pickObject po =  collision.gameObject.GetComponent<pickObject>();

            if(po != null)//�ɼ�����Ʒ
            {
                InventoryManaget.Instance.AddItem(po.itemso);//��ӵ��ֿ���
                Destroy(po.gameObject);//����

            }
        }
    }
}
