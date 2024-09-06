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

            if(po != null)//可见其物品
            {
                InventoryManaget.Instance.AddItem(po.itemso);//添加到仓库中
                Destroy(po.gameObject);//消除

            }
        }
    }
}
