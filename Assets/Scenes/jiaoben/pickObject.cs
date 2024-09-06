using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class pickObject : jiaohuFather
{
    public itemSO itemso;
    protected override void jiaohu()
    {
        Destroy(this.gameObject);
        InventoryManaget.Instance.AddItem(itemso);
    }

}
