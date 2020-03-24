using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIsetting : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject [] depot= new GameObject[3];
    GameObject mid;
    public GameObject p0, p1, p2, p3;
    private int midnum;
    private bool depotopen = false;
    void Start()
    {
        initial();        
    }

    // Update is called once per frame
    void Update()
    {
        B_depotopen();
        U_select();
    }
    void initial()
    {
        depot[0] = p1;
        depot[1] = p2;
        depot[2] = p3;

        mid = Instantiate(depot[0] ,new Vector3(0,0,0), Quaternion.identity, p0.transform);
        RectTransform rt = mid.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector3(0, 0, 0);

        midnum = 0;
    }
    void U_select()
    {
        if (depotopen == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && midnum < 2)
            {
                Destroy(mid);
                midnum++;
                mid = Instantiate(depot[midnum], new Vector3(0, 0, 0), Quaternion.identity, p0.transform);
                RectTransform rt = mid.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector3(0, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && midnum > 0)
            {
                Destroy(mid);
                midnum--;
                mid = Instantiate(depot[midnum], new Vector3(0, 0, 0), Quaternion.identity, p0.transform);
                RectTransform rt = mid.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector3(0, 0, 0);
            }
        }  
    }

    void B_depotopen()
    {
        if (Input.GetKeyDown(KeyCode.E) && depotopen == false)
        {
            depotopen = true;
        }
        else if(Input.GetKeyDown(KeyCode.E) && depotopen == true)
        {
            depotopen = false;
        }
    }
}
