using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDBManager : MonoBehaviour
{
    public static itemDBManager Instance { get; private set; }

    public itemDESO itemDB;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    public itemSO GetRandomItem()
    {
        int randomIndex = Random.Range(0, itemDB.ItemList.Count);
        return itemDB.ItemList[randomIndex];
    }
}
