using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : jiaohuFather
{
    public string name;
    public string[] contentList;
    public DialogueUI dialogueUI;
    protected override void jiaohu()
    {
        DialogueUI.Instance.Show(name, contentList);

        //dialogueUI.Show(name, contentList);
    }
}
    
