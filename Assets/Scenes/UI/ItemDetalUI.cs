using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemDetalUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;
    public GameObject propertyGrid ;
    public GameObject propertyTemplate;

    private itemSO itemSO;
    private itemUI itemUI;
    

    private void Start()
    {
        propertyTemplate.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void UpdateItemDetailUI(itemSO itemSo,itemUI itemUI)
    {
        this.itemSO = itemSo;
        this.itemUI = itemUI;
        this.gameObject.SetActive(true);


        string type = "";
        switch (itemSo.itemType)
        {
            case ItemType.Weapon:
                type = "武器"; break;
            case ItemType.Consumable:
                type = "可消耗品"; break;
        }
        iconImage.sprite = itemSo.icon;
        nameText.text = itemSo.name;
        typeText.text = type;
        descriptionText.text = itemSo.descripttion;

        foreach(Transform child in propertyGrid.transform)
        {
            if (child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }
        foreach(Property property in itemSo.propertyList)
        {
            string propertyStr = "";
            string propertyName = "";
            switch (property.propertyType)
            {
                case PropertyType.HPValue:
                    propertyName = "生命值:";
                    break;
                case PropertyType.EnergyValue:
                    propertyName = "饥饿值:";
                    break;
                case PropertyType.MentalValue:
                    propertyName = "精神值:";
                    break;
                case PropertyType.SpeedValue:
                    propertyName = "速度:";
                    break;
                case PropertyType.AttackValue:
                    propertyName = "攻击力:";
                    break;
                default:
                    break;
            }
            propertyStr += propertyName;
            propertyStr += property.value;
            GameObject go =  GameObject.Instantiate(propertyTemplate);
            go.SetActive(true);
            //go.transform.parent = propertyGrid.transform;
            go.transform.SetParent(propertyGrid.transform);
            go.transform.Find("Property").GetComponent<TextMeshProUGUI>().text = propertyStr;
        }

        
    }

    public void OnUseButtonClick()
    {
       InvertoryUI.Instance.OnItemUse(itemSO,itemUI);
       this.gameObject.SetActive(false);

    }
}
