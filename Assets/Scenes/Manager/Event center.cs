using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventcenter : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyDied;//没有一个敌人死亡就注册这个事件

    public static void EnemyDied(Enemy enemy)
    {
        OnEnemyDied?.Invoke(enemy);
    }
}
