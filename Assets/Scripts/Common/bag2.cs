using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag2 : MonoBehaviour
{
    public List<GameObject> itemdata;
    public GameObject pack;
    c_bag bg = new c_bag();
    string _itemname;
    private GameObject tsf;
    private gamstatus game;
    // Start is called before the first frame update
    void Start()
    {
        game = gamstatus.onplaying;
        bg.I_name = new List<string>();
        bg.I_num = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        callpack();
    }
    void callpack()
    {
        if (Input.GetKeyDown(KeyCode.Return) && game == gamstatus.onplaying)
        {
            this.gameObject.GetComponent<CharacterController2D>().c_pack = true;
            game = gamstatus.onbaging;

            Instantiate(pack);
            tsf = GameObject.Find("itemcreat");
            creatitem();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && game == gamstatus.onbaging)
        {
            this.gameObject.GetComponent<CharacterController2D>().c_pack = false;
            game = gamstatus.onplaying;

            Destroy(GameObject.Find("pack2(Clone)"));
        }
    }
    void creatitem()
    {
        foreach (string item in bg.I_name)
        {
            foreach (GameObject s in itemdata)
            {                
                if (s.name == item)
                {
                    Instantiate(s ,tsf.transform);
                }
            }
        }
    }
    void showbag()
    {
        foreach(string i in bg.I_name)
        print(i);
    }
    void selected()
    {
        if (bg.I_name.Contains(_itemname))
        {
            int num = bg.I_name.IndexOf(_itemname);
            bg.I_num[num]++;
        }
        else
        {
            bg.I_name.Add(_itemname);
            bg.I_num.Add(1);            
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {        
        if (Input.GetKeyDown(KeyCode.C) && other.tag == "item")
        {
            _itemname = other.GetComponent<Itemset>().o_name;
            selected();
            showbag();            
        }
    }
} 

public class c_bag
{
    public List<string> I_name;
    public List<int> I_num;
}
public class it_val
{
    public string name;
}
enum gamstatus
{
    onplaying,
    onbaging
}

