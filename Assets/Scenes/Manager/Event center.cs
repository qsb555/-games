using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventcenter : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyDied;//û��һ������������ע������¼�

    public static void EnemyDied(Enemy enemy)
    {
        OnEnemyDied?.Invoke(enemy);
    }
}
