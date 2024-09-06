using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class playerTest : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isCollide = Physics.Raycast(ray,out hit);
            if (isCollide)
            {
                if(hit.collider.tag =="Ground")
                {
                    //自动导航到目标位置
                    playerAgent.SetDestination(hit.point);
                }
                else if(hit.collider.tag == "jiaohu")
                {
                    hit.collider.GetComponent<jiaohuFather>().OnClick(playerAgent);
                    
                }

           
            }
        }
    }
}
