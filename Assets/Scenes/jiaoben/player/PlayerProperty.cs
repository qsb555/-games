using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    //通过字典管理属性
    public Dictionary<PropertyType, List<Property>> propertyDict;
    public int hpValue = 100;  

    public int energyValue = 100;
    public int mentalValue = 100;
    public int level = 1;
    public int currentExp = 0;


    public void UseDrug(itemSO itemSO)
    {//药品使用
        foreach(Property p in itemSO.propertyList)
        {
            AddProperty(p.propertyType, p.value);
        }

    }

    void Awake()
    {
        propertyDict = new Dictionary<PropertyType, List<Property>>();
       
        propertyDict.Add(PropertyType.SpeedValue, new List<Property>());
        propertyDict.Add(PropertyType.AttackValue, new List<Property>());

        AddProperty(PropertyType.SpeedValue, 5);
        AddProperty(PropertyType.AttackValue, 20);

        Eventcenter.OnEnemyDied += OnEnenyDied;
    }
    public void AddProperty(PropertyType pt,int value)
    {
        switch (pt)
        {
            case PropertyType.HPValue:
                hpValue += value;
                return;
            case PropertyType.EnergyValue:
                energyValue += value;
                return;
            case PropertyType.MentalValue:
                mentalValue += value;
                return;
        }


        List<Property> list;
        propertyDict.TryGetValue(pt, out list);
        list.Add(new Property(pt,value));

    }
    public void RemoveProperty(PropertyType pt, int value)
    {
        switch (pt)
        {
            case PropertyType.HPValue:
                hpValue -= value;
                return;
            case PropertyType.EnergyValue:
                energyValue -= value;
                return;
            case PropertyType.MentalValue:
                mentalValue -= value;
                return;
        }
        List<Property> list;
        propertyDict.TryGetValue(pt, out list);
        list.Remove(list.Find(x => x.value == value));
    }
    private void OnDestroy()
    {
        Eventcenter.OnEnemyDied -= OnEnenyDied;

    }
    private void OnEnenyDied(Enemy enemy)
    {
        this.currentExp += enemy.exp;
        if(currentExp >= level * 30)
        {
            currentExp -= level * 30;
            level++;
        }
        PlayerPropertyUI.Instace.UpdatePlayerPropertyUI();
    }
    
}
