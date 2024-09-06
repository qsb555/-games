using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class InvertoryUI : MonoBehaviour
{
    public static InvertoryUI Instance { get; private set; }
    private GameObject uiGameObject;
    private GameObject content;
    public GameObject itemPrefab;
    private bool isShow=false;

    public ItemDetalUI itemDetalUI;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }


    void Start()
    {
        uiGameObject = transform.Find("UI").gameObject;
        content = transform.Find("UI/Bg/Scroll View/Viewport/Content").gameObject;
        Hide();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isShow)
            {
                Hide();
                isShow = false;
            }
            else
            {
                Show();
                isShow = true;
            }
        }
    }

    public void Show()
    {
        uiGameObject.SetActive(true);
    }
    public void Hide()
    {
        uiGameObject.SetActive(false);
    }
    public void AddItem(itemSO itemSO)
    {
        GameObject itemGo = GameObject.Instantiate(itemPrefab);
        itemGo.transform.SetParent(content.transform);
        itemUI itemui = itemGo.GetComponent<itemUI>();

        itemui.InitTtem(itemSO);
    }
    public void OnItemClick(itemSO itemSO,itemUI itemUI)
    {
        itemDetalUI.UpdateItemDetailUI(itemSO,itemUI);

    }
    public void OnItemUse(itemSO itemSO,itemUI itemUI)
    {
        Destroy(itemUI.gameObject);
        InventoryManaget.Instance.RemoveItem(itemSO);

        GameObject.FindGameObjectWithTag(Tag.PLAYER).GetComponent<player>().UseItem(itemSO);
    }
}
