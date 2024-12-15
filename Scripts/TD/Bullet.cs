using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Atk;
    public Collider target;
    public float speed = 5f;

    // Start���ڵ�һ֡����ǰ����һ��
    void Start()
    {

    }

    // Updateÿ֡���ᱻ����һ��
    void Update()
    {
        if (target != null)
        {
            // �����ӵ�ָ��Ŀ��ķ�������
            Vector3 direction = (target.transform.position - transform.position).normalized;
            // ���ӵ����Ÿ÷����ƶ�
            transform.position += direction * speed * Time.deltaTime;
            // ʹ�ӵ��ĳ����׼Ŀ�꣨����ֻ�Ǽ򵥵����ӵ�����Ŀ�귽��
            transform.forward = direction;

            float distance = Vector3.Distance(transform.position, target.transform.position);
            Monsterclass monsterclass= target.GetComponent<Monsterclass>();
            if (distance < 0.5f)
            {
                // ������С����ֵʱ�������ӵ�
                Destroy(gameObject);

                #region �˺�����
                if (Atk < monsterclass.DEF) Atk = 3;//�̶���С�˺�
                else Atk-=(float)monsterclass.DEF;
                monsterclass.HP-=Atk;
                #endregion
            }
        }
        else
        {
            Destroy (gameObject);//Ŀ���������¶�ʧ
        }
    }
}
