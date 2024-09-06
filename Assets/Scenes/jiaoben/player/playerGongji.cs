using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGongji : MonoBehaviour
{
    public wuqi wuqi;
    public Sprite weaponIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wuqi != null && Input.GetKeyDown(KeyCode.Space))
        {
            wuqi.Attack();
        }
    }

    public void Loadwuqi(wuqi wuqi)
    {
        this.wuqi = wuqi;
    }
    public void Loadwuqi(itemSO itemSO)
    {
        if(wuqi != null)
        {
            Destroy(wuqi.gameObject);
        }

        //º”‘ÿŒ‰∆˜
        string prefabName = itemSO.prefab.name;
        Transform weaponParent =   transform.Find(prefabName + "position");
        GameObject weaponGo =   GameObject.Instantiate(itemSO.prefab);
        weaponGo.transform.parent = weaponParent;
        weaponGo.transform.localPosition = Vector3.zero;
        weaponGo.transform.localRotation = Quaternion.identity;

        this.wuqi = weaponGo.GetComponent<wuqi>();
        this.weaponIcon = itemSO.icon;

        PlayerPropertyUI.Instace.UpdatePlayerPropertyUI();
    }
    public void Unloadwuqi()
    {
        wuqi = null;
    }


}
