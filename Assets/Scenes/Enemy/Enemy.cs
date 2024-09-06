using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //����----ս��
    //�ƶ�״̬
    private NavMeshAgent enemyAgent;
    //��Ϣ
    private EnemyState state = EnemyState.NormalState;
    private EnemyState childState = EnemyState.RestingState;//    Ĭ����Ϣ״̬

    public float restTime = 2; //��Ϣʱ��
    private float restTimer = 0;//��ʱ��

    public int HP = 100;

    public int exp = 20;
    public enum EnemyState
    {
        NormalState,//����״̬
        FightingState,//ս��״̬
        MovingState,//�ƶ�״̬
        RestingState//��Ϣ״̬
    }

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == EnemyState.NormalState)//�ж�������״̬����ս��״̬
        {
            if(childState == EnemyState.RestingState)
            {
                restTimer += Time.deltaTime;

                if(restTimer > restTime)//��Ϣʱ�䵽��ʼ�ƶ�
                {
                    Vector3 randomPosition = FindRandomPosition();//��λ��
                    enemyAgent.SetDestination(randomPosition);//����Ŀ��λ��
                    childState = EnemyState.MovingState;//״̬�޸�
                }
            }else if(childState == EnemyState.MovingState)
            {
                if(enemyAgent.remainingDistance <= 0) //��Ŀ��λ��
                {//������Ϣʱ��
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
    {    //�õ��������
        Vector3 randomDir = new Vector3(Random.Range(-1, 1f), 0, Random.Range(-1, 1f));
          //���λ��
        return transform.position +  randomDir.normalized * Random.Range(2, 5);
    }

    //��������
    public void TakeDamage(int damage)
    {
        HP -= damage;//���˼�Ѫ

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
