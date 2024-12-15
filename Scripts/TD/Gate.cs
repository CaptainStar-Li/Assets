using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    #region ��ʱ��
    private float timer = 0f;
    // ��������ʱ�䣬��������Ϊ1�룬����Ը����������
    private float ddl = 2f;
    #endregion

    #region ������
    private int num = 0;
    private int ddn = 100;
    #endregion

    private System.Random random;
    private GameObject cachedMonsterPrefab;

    void Start()
    {
        random = new System.Random();
        cachedMonsterPrefab = Resources.Load<GameObject>("Prefabs/TD/Enemy/Monster");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ddl)
        {
            num++;
            if (num >= ddn)
            {
                return;
            }

            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            float x = 80;
            float y = 80;
            int pd = random.Next(1, 3);
            if (pd == 1)
            {
                x *= -1;
            }

            y = random.Next(-80, 81);

            pd = random.Next(1, 3);
            if (pd == 1)
            {
                //(x,y)
                GameObject NewMonster = Instantiate(cachedMonsterPrefab);
                NewMonster.transform.position = new Vector3(x, y, 0);
                NewMonster.GetComponent<Monster>().target = playerObject;
            }
            else
            {
                //(y,x)
                GameObject NewMonster = Instantiate(cachedMonsterPrefab);
                NewMonster.transform.position = new Vector3(y, x, 0);
                NewMonster.GetComponent<Monster>().target = playerObject;
            }

            timer = 0f;
        }
    }
}