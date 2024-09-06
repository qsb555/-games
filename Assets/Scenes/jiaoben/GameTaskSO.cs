using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum GameTaskState
{
    Waiting,
    Executing,
    Completed,
    End
}
[CreateAssetMenu]
public class GameTaskSO :ScriptableObject
{
    public GameTaskState state;

    public string[] diague;

    public itemSO startReward;
    public itemSO endReward;

    public int currentEnemyNeed = 10;
    public int currentEnemyCount = 0;


    public void Start()
    {
        currentEnemyCount = 0;
        state = GameTaskState.Executing;
        Eventcenter.OnEnemyDied += OnEnemyDied;
    }
    private void OnEnemyDied(Enemy enemy)
    {
        if (state == GameTaskState.Completed) return;
        currentEnemyCount++;
        if(currentEnemyCount >= currentEnemyNeed)
        {
            state = GameTaskState.Completed;
            MessageUI.Instance.Show("任务已完成请提交");

        }
    }
    public void End()
    {
        state = GameTaskState.End;
        Eventcenter.OnEnemyDied -= OnEnemyDied;
    }

}
