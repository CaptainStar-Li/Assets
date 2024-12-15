using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCheck : MonoBehaviour
{
    #region ��ʱ��
    private float timer = 0f;
    // ��������ʱ�䣬��������Ϊ1�룬����Ը����������
    private float ddl = 1f;
    #endregion

    private Towerclass Tower;
    private float checkRadius;

    void Start()
    {
        Tower = GetComponent<Towerclass>();
        checkRadius=Tower.Radius;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >=ddl) 
        { 
            Collider[] colliders = Physics.OverlapSphere(transform.position,checkRadius);
            foreach (Collider collider in colliders)
            {
                //Debug.Log(collider.name);
                if (collider.CompareTag("Enemy"))
                {
                    //Debug.Log(collider.gameObject.name);
                    // transform.LookAt(collider.transform);
                    Attack(collider);
                    break;
                }
            }
            timer = 0f;
        }

    }

    void Attack(Collider target)
    {

        float atk = Tower.ATK;
        //Debug.Log(atk);

        #region �����ӵ�
        //Debug.Log(target);
        string BulletName =Tower.BulletName;
        GameObject NewBullet = Instantiate(Resources.Load<GameObject>($"Prefabs/TD/Bullet/{BulletName}"));
        NewBullet.transform.position = this.transform.position;
        Bullet bullet=NewBullet.GetComponent<Bullet>();
        bullet.target= target;
        bullet.Atk = atk;
        #endregion
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector3)transform.position,checkRadius);
    }
}
