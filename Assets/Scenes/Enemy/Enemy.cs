using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //正常----战斗
    //移动状态
    private NavMeshAgent enemyAgent;
    //休息
    private EnemyState state = EnemyState.NormalState;
    private EnemyState childState = EnemyState.RestingState;//    默认休息状态

    public float restTime = 2; //休息时间
    private float restTimer = 0;//计时器

    public int HP = 100;

    public int exp = 20;
    public enum EnemyState
    {
        NormalState,//正常状态
        FightingState,//战斗状态
        MovingState,//移动状态
        RestingState//休息状态
    }

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == EnemyState.NormalState)//判断是正常状态还是战斗状态
        {
            if(childState == EnemyState.RestingState)
            {
                restTimer += Time.deltaTime;

                if(restTimer > restTime)//休息时间到开始移动
                {
                    Vector3 randomPosition = FindRandomPosition();//新位置
                    enemyAgent.SetDestination(randomPosition);//设置目标位置
                    childState = EnemyState.MovingState;//状态修改
                }
            }else if(childState == EnemyState.MovingState)
            {
                if(enemyAgent.remainingDistance <= 0) //到目标位置
                {//计入休息时间
                    restTimer = 0;
                    childState = EnemyState.RestingState;
                    
                }
            }
        }
       //if (Input.GetKeyDown(KeyCode.Space))
       //{
       //    TakeDamage(30);
       //}
    }
    
    Vector3 FindRandomPosition()
    {    //得到随机方向
        Vector3 randomDir = new Vector3(Random.Range(-1, 1f), 0, Random.Range(-1, 1f));
          //随机位移
        return transform.position +  randomDir.normalized * Random.Range(2, 5);
    }

    //敌人受伤
    public void TakeDamage(int damage)
    {
        HP -= damage;//受伤减血

        if(HP <= 0)
        {
            Die();

        }
    }

    private void Die()
    {
        GetComponent<Collider>().enabled = false;

        int count = Random.Range(0, 4);
        for (int i = 0; i < count; i++)
        {
            SpawnpickableItem();
        }

        Eventcenter.EnemyDied(this);
        Destroy(this.gameObject);
    }

    private void SpawnpickableItem()
    {
        itemSO item = itemDBManager.Instance.GetRandomItem();
        GameObject go = GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
        go.tag = Tag.JIAOHU;
        Animator anim = go.GetComponent<Animator>();
        if (anim != null)
        {
            anim.enabled = false;
        }
        pickObject po = go.AddComponent<pickObject>();
        po.itemso = item;

        Collider collider = go.AddComponent<Collider>();
        if(collider != null)
        {
            collider.enabled = true;
            collider.isTrigger = false;
        }
        Rigidbody rgd = go.GetComponent<Rigidbody>();
        if(rgd != null)
        {
            rgd.isKinematic = false;
            rgd.useGravity = true;
        }

    }
}
