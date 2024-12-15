using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    public float offset;//��ֱ������ƫ����

    public Transform tr;//���ָ������

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        tr=GetComponentInParent<Transform>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position= new Vector3(tr.position.x,tr.position.y+offset,tr.position.z);

        transform.LookAt(transform.position +cam.transform.rotation * Vector3.forward,cam.transform.rotation * Vector3.up);
    }
}
