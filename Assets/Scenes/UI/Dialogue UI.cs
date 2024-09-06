using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;

    public List<string> contentList;

    private int contentIndex = 0;

    private GameObject uiGameObject;

    private Action OnDialogueEnd;

    private void Awake()
    {

        Instance = this;
    }
    void Start()
    {
        nameText = transform.Find("UI/namebg/nametest").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("UI/bgtest").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("UI/Button").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnCountinnueButtonClick);
        uiGameObject = transform.Find("UI").gameObject;
        Hide();
    }
    public void show()
    {
        uiGameObject.SetActive(true);
    }
    public void Show(string name, string[] content,Action OnDiagoueEnd = null)
    {
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentIndex = 0;//น้มใ
        contentText.text = contentList[0];
        uiGameObject.SetActive(true);
        this.OnDialogueEnd = OnDiagoueEnd;
    }
    public void Hide()
    {
        uiGameObject.SetActive(false);
    }
    private void OnCountinnueButtonClick()
    {
        contentIndex++;
        if(contentIndex >= contentList.Count)
        {
            OnDialogueEnd?.Invoke();
            Hide();
            return;
        }
        contentText.text = contentList[contentIndex];
    }
}
