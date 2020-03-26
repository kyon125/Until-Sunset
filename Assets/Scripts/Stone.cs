using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{

    private bool isClick = false;
    public Transform startPos;
    public float maxDis = 1.5f;
    private SpringJoint2D sp;
    private Rigidbody2D rb;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        isClick = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isClick = false;
        rb.isKinematic = false;
        Invoke("fly", 0.1f);
    }

    private void Update()
    {
        if(isClick)
        {
            transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

            if (Vector3.Distance(transform.position, startPos.position) > maxDis) // 長度限制 
            {
                Vector3 pos = (transform.position - startPos.position).normalized; // 單位化向量
                pos *= maxDis; // 向量最大化
                transform.position = pos + startPos.position;
            }

        }
    }

    void fly()
    {
        sp.enabled = false;
    }
       
}
