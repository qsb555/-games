using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class itemSO : ScriptableObject
{
    public int id;
    public string name;
    public ItemType itemType;
    public string descripttion;
    public List<Property> propertyList; //属性列表
    public Sprite icon;//图标
    public GameObject prefab;


}
public enum ItemType
{
    Weapon,
    Consumable
}
//属性列表  属性类
[Serializable]  //标志可序列化
public class Property
{
    public PropertyType propertyType;//具体对象
    public int value; //具体值大小
    public Property()
    {

    }
    public Property(PropertyType propertyType,int value)
    {
        this.propertyType = propertyType;
        this.value = value;
    }

}
public enum PropertyType
{
    HPValue,//血量
    EnergyValue,//饥饿值
    MentalValue,//精神值
    SpeedValue,//速度
    AttackValue//攻击
}

