using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wuqi2 : wuqi
{
    public GameObject bulletPrefab;
    public float bulletSpeed;//�ٶ�
    private GameObject bulletGo;

    private void Start()
    {
        SpawmBullet();

    }
    public override void Attack()
    {
        if(bulletGo != null)
        {
            bulletGo.transform.parent = null;
            bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            bulletGo.GetComponent<Collider>().enabled = true;//������ײ����

            Destroy(bulletGo, 10);
            bulletGo = null;
            Invoke("SpawmBullet", 0.5f);
        }
        else
        {
            return;
        }

    }
    public float gravityScale = 1f;
    private void SpawmBullet()
    {
        bulletGo = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletGo.GetComponent<Collider>().enabled = false;

        bulletGo.transform.parent = transform;//��ʼ��������

        if (tag == Tag.JIAOHU)
        {
            Destroy(bulletGo.GetComponent<wuqibullet>());//�ѿ����������ٵ����ȥ��
            bulletGo.tag = Tag.JIAOHU;
            
            pickObject po =  bulletGo.AddComponent<pickObject>();
            po.itemso = GetComponent<pickObject>().itemso;
            Rigidbody rgd = bulletGo.GetComponent<Rigidbody>();

            //rgd = GetComponent<Rigidbody>();
            rgd.useGravity = true;
            rgd.constraints = ~RigidbodyConstraints.FreezePositionY;
            bulletGo.GetComponent<Collider>().enabled = true;

        }
    }
}
