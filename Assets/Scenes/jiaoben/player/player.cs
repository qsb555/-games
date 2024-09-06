using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private playerGongji playerGongji;
    private PlayerProperty playerProperty;
    private void Start()
    {
        playerGongji = GetComponent<playerGongji>();
        playerProperty = GetComponent<PlayerProperty>();
    }
    public void UseItem(itemSO itemSO)
    {
        switch (itemSO.itemType)
        {
            case ItemType.Weapon:
                playerGongji.Loadwuqi(itemSO);
              
                break;
            case ItemType.Consumable:
                playerProperty.UseDrug(itemSO);
                break;
            default:
                break;
        }
    }
}
