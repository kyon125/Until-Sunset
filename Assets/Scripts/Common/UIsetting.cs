using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIsetting : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject [] depot= new GameObject[3];
    GameObject mid,left,right, _t_select;
    public GameObject p0, p1, p2, p3, t_select;
    private int midnum,leftnum,rightnum;
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

        leftnum = 0;
        midnum = 1;
        rightnum = 2;
    }
    void create()
    {
        Destroy(mid);
        Destroy(right);

        right = Instantiate(depot[0], p0.transform);
        left = Instantiate(depot[midnum - 1], p0.transform);
        mid = Instantiate(depot[midnum], p0.transform);        

        mid.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        right.GetComponent<RectTransform>().anchoredPosition = new Vector3(35, 0, 0);
    }
    void U_select()
    {     
        if (depotopen == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && midnum < 2)
            {
                midnum++;
                create();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && midnum == 2)
            {
                midnum = 0;
                create();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && midnum > 0)
            {
                midnum--;
                create();
            }
        }  
    }

    void B_depotopen()
    {
        if (Input.GetKeyDown(KeyCode.E) && depotopen == false)
        {
            _t_select = Instantiate(t_select, p0.transform);
            depotopen = true;
        }
        else if(Input.GetKeyDown(KeyCode.E) && depotopen == true)
        {
            Destroy(_t_select);
            depotopen = false;            
        }
    }

    
}
