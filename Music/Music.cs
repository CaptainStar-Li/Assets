using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicPlayers = GameObject.FindGameObjectsWithTag("MusicPlayer");
        if (musicPlayers.Length > 1)
        {
            // ������ڶ������������
            Destroy(this.gameObject);
        }
        else
        {
            // ��ֹ�����Ϸ�����ڼ����³���ʱ������
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
