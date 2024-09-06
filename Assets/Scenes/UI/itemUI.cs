using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class itemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;

    public itemSO itemSo;
    public void InitTtem(itemSO itemSo) 
    {
        string type = "";
        switch (itemSo.itemType)
        {
            case ItemType.Weapon:
                type = "ÎäÆ÷"; break;
            case ItemType.Consumable:
                type = "¿ÉÏûºÄÆ·"; break;
        }
        iconImage.sprite = itemSo.icon;
        nameText.text = itemSo.name;
        typeText.text = type;
        this.itemSo = itemSo;
    }

    public void OnClick()
    {
        InvertoryUI.Instance.OnItemClick(itemSo,this);
    }
    
}
