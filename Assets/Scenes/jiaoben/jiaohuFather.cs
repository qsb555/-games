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
        //移动到目标附近
        playerAgent.stoppingDistance = 2;
        playerAgent.SetDestination(transform.position);
        have = false;
        
    }
    private void Update()
    {                                       //=false时路径计算完了
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
