using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIsetting : MonoBehaviour
{
    // Start is called before the first frame update\
    private string[] packid = new string [20];
    public GameObject p0, p1, p2;

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
        p0.GetComponent<Image>().sprite = this.gameObject.GetComponent<Backpacage>().ITEM[0].GetComponent<Image>().sprite;
    }
    void create()
    {
       
    }
    void U_select()
    {     
       
    }

    void B_depotopen()
    {
        
    }

    
}
