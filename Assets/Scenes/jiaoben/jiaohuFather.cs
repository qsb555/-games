using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class jiaohuFather : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    private bool have = false;
    public void OnClick(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        //�ƶ���Ŀ�긽��
        playerAgent.stoppingDistance = 2;
        playerAgent.SetDestination(transform.position);
        have = false;
        
    }
    private void Update()
    {                                       //=falseʱ·����������
        if (playerAgent != null && playerAgent.pathPending == false && have ==false)
        {
            if(playerAgent.remainingDistance <= 2)
            {
                jiaohu();
                have = true;
            }
          
        }
    }
    protected virtual void jiaohu()
    {
        print("1111111111");
    }
}
