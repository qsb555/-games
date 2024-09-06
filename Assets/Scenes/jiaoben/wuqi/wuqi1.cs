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
        //播放动画
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
    private void OnTriggerEnter(Collider other)//判断镰刀与那些物体发生碰撞
    {
        if(other.tag == Tag.ENEMY)
        {
            other.GetComponent<Enemy>().TakeDamage(atkValue);
           
        }
    }
}
