using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wuqibullet : MonoBehaviour
{
    private Rigidbody rgd;
    private Collider col;
    public int atkValue = 30;     //�˺�ֵ
    private void Start()
    {
        rgd = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
       
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tag.PLAYER )
        {
            return;
        }
        //��ײ�󱣳�������
        rgd.velocity = Vector3.zero;
        if (tag == Tag.JIAOHU)
        {
            rgd.isKinematic = false;
            rgd.useGravity = true;
            CapsuleCollider collidei = GetComponent<CapsuleCollider>();
            collidei.enabled = true;//�������ǽ������������true���Ǽ��������

        }
        else
        {
            rgd.isKinematic = true;
            col.enabled = false;

            transform.parent = collision.gameObject.transform;

            if (tag != "jiaohu")
            {
                Destroy(this.gameObject, 2f);//1�������
            }
            if (collision.gameObject.tag == Tag.ENEMY)
            {
                    collision.gameObject.GetComponent<Enemy>().TakeDamage(atkValue);
            }
            
        }
    }
}
