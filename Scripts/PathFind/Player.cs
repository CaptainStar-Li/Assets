using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;

    public LineRenderer lineRenderer;//����·�߻���
    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))//����������Ƿ��ɿ�
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
            /*
             * ͨ�� Physics.Raycast �������߼��
             * �����������Camera.main�������������Ļ�ϵ�λ�ã�Input.mousePosition������һ������
             * ��������볡���е���ײ���ཻ�������ж�Ϊ true������ if ������ִ�к�������
             * ��û���ཻ���������� if ���顣
            */
            {
                print(hit.collider.name);//ֱ�۵�֪�����߻������ĸ�����
                agent.isStopped = false;//��ʼ�ƶ���ȡ��֮ǰ���ܴ��ڵ�ֹͣ״̬
                agent.SetDestination(hit.point);//�������Ŀ�ĵ��ƶ�
            }
        }

        if (!agent.pathPending && agent.pathStatus == NavMeshPathStatus.PathComplete)//agent ��·�������ڹ���,�������������Ѿ����������õ�״̬
        {
            //Debug.Log("FindPath");
            DrawPath();//������·��
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            agent.isStopped = true;//ֹͣ�ƶ�
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            GameObject NewTower = Instantiate(Resources.Load<GameObject>("Prefabs/TD/Tower/Tower"));
            NewTower.transform.position=this.transform.position;
        }
    }

    void DrawPath()
    {
        Vector3[] PlayerPath=agent.path.corners;//��������������滮����·���ϵĹսǵ㣨�ڵ㣩�ļ���
        lineRenderer.positionCount=PlayerPath.Length;
        for (int i = 0; i < PlayerPath.Length; i++) 
        {
            Vector3 p = PlayerPath[i];
            lineRenderer.SetPosition(i,p);//����ǰ���� i ��Ӧ�Ķ���λ������Ϊ�ոմ� path �����л�ȡ�ĵ� p ������
        }
    }
}
