using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    #region ��ʱ��
    private float timer = 0f;
    // ��������ʱ�䣬��������Ϊ1�룬����Ը����������
    private float ddl = 1f;
    #endregion

    private NavMeshAgent agent;

    public GameObject target;

    public GameObject Player;

    private int state;//����Ѱ·״̬
                      //1--Ѱ��Player  
                      //2--Ѱ�ҷ�����
                      //3--����������

    private float checkRadius;//���а뾶

    private Towerclass tower;//�������ķ�����

    private float Atk;//���ﵱǰ������


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = 1;
        Player = GameObject.FindGameObjectWithTag("Player");
        checkRadius = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 1:
                target = Player;
                agent.SetDestination(target.transform.position);
                Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius);
                float PlayerDistance=Vector3.Distance(transform.position,Player.transform.position);
                foreach (Collider collider in colliders)
                {
                    //Debug.Log(collider.name);
                    if (collider.CompareTag("Tower"))
                    {
                        float distance= Vector3.Distance(transform.position, collider.gameObject.transform.position);
                        if (PlayerDistance < distance) continue;
                        //Debug.Log(collider.gameObject.name);
                        // transform.LookAt(collider.transform);
                        target= collider.gameObject;
                        tower = target.GetComponent<Towerclass>();           
                        Atk = GetComponent<Monsterclass>().ATK;
                        state = 2;
                        break;
                    }
                }

                break;

            case 2:
                if (target == null)
                {
                    target = Player;
                    agent.SetDestination(target.transform.position);
                    state = 1;
                    break;
                }
                else if(agent.remainingDistance<1.2f)//�������һ�����뿪ʼ����������
                {
                    agent.ResetPath();
                    state = 3;
                    break;
                }

                agent.SetDestination(target.transform.position);
                break;

            case 3:
                AttackTower();
                return;

            default:
                target = Player;
                agent.SetDestination(target.transform.position);
                break;
        }
    }

    void AttackTower()
    {
        if (target == null)
        {
            target = Player;
            agent.SetDestination(target.transform.position);
            state = 1;
            return;
        }
        timer += Time.deltaTime;
        if (timer >= ddl)
        {
            #region �˺�����
            if (Atk < tower.DEF) Atk = 3;//�̶���С�˺�
            else Atk -= (float)tower.DEF;
            tower.HP -= Atk;
            #endregion
            timer = 0f;
        }
    }
}
