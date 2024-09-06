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
    public List<Property> propertyList; //�����б�
    public Sprite icon;//ͼ��
    public GameObject prefab;


}
public enum ItemType
{
    Weapon,
    Consumable
}
//�����б�  ������
[Serializable]  //��־�����л�
public class Property
{
    public PropertyType propertyType;//�������
    public int value; //����ֵ��С
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
    HPValue,//Ѫ��
    EnergyValue,//����ֵ
    MentalValue,//����ֵ
    SpeedValue,//�ٶ�
    AttackValue//����
}

