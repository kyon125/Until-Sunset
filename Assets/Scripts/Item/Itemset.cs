using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Itemset : MonoBehaviour
{
    public string o_name;
    public bool
        aa, bb, cc, dd, ee;
    item it;
    // Start is called before the first frame update
    void Start()
    {
        it = new item();
        test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void test()
    {
        it._id = o_name;
    }   
}
public class item
{
    public string _id;
}

