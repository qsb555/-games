using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class wuqi1 : wuqi 
{
    private Animator anim;
    public int atkValue = 100;

    private void Start()
    {
        //���Ŷ���
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
       //     Attack();
       // }
    }

    public override void Attack()
    {
        anim.SetTrigger("isGongji");
    }
    private void OnTriggerEnter(Collider other)//�ж���������Щ���巢����ײ
    {
        if(other.tag == Tag.ENEMY)
        {
            other.GetComponent<Enemy>().TakeDamage(atkValue);
           
        }
    }
}
