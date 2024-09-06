using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManaget : MonoBehaviour
{
    public static InventoryManaget Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public List<itemSO> itemList;
    public itemSO defaultWeapon;

 
    public void AddItem(itemSO item)
    {
        itemList.Add(item);
        InvertoryUI.Instance.AddItem(item);
        MessageUI.Instance.Show("你获得了一个物品:" + item.name);
    }
    public void RemoveItem(itemSO itemSO)
    {
        itemList.Remove(itemSO);
    }
}
