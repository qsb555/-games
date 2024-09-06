using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskNPCObject : jiaohuFather
{
    public string npcname;
    public GameTaskSO gameTaskSO;

    public string[] contenInTaskExecuting;
    public string[] contenInTaskCompleted;
    public string[] contenInTaskEed;



    public void Start()
    {
        gameTaskSO.state = GameTaskState.Waiting;
    }
    protected override void jiaohu()
    {

        switch (gameTaskSO.state)
        {
            case GameTaskState.Waiting:
                DialogueUI.Instance.Show(npcname, gameTaskSO.diague, OnDialongueEnd);
                break;
            case GameTaskState.Executing:
                DialogueUI.Instance.Show(npcname, contenInTaskExecuting);
                break;
            case GameTaskState.Completed:
                DialogueUI.Instance.Show(npcname, contenInTaskCompleted, OnDialongueEnd);
                break;
            case GameTaskState.End:
                DialogueUI.Instance.Show(npcname, contenInTaskEed);

                break;
            default:
                break;

        }

    }

    public void OnDialongueEnd()
    {
        switch (gameTaskSO.state)
        {
            case GameTaskState.Waiting:
                gameTaskSO.Start();
                InventoryManaget.Instance.AddItem(gameTaskSO.startReward);
                MessageUI.Instance.Show("你接受了一个任务");

                break;
            case GameTaskState.Executing:
                break;
            case GameTaskState.Completed:
                gameTaskSO.End();
                InventoryManaget.Instance.AddItem(gameTaskSO.endReward);
                MessageUI.Instance.Show("任务已经提交");

                break;
            case GameTaskState.End:
                break;
            default:
                break;

        }
    }
}
