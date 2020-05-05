using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    public List<GameObject> itemdata;
    public GameObject pack, com;
    public c_bag bg = new c_bag();
    public List<GameObject> comitem;
    string _itemname;
    private GameObject tsf;    
    public gamstatus game;
    // Start is called before the first frame update
    void Start()
    {
        game = gamstatus.onplaying;
        bg.I_name = new List<string>();
        bg.I_num = new List<int>();
        comitem = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        callpack();
    }
    protected void callpack()
    {
        if (Input.GetKeyDown(KeyCode.Return) && game == gamstatus.onplaying)
        {
            this.gameObject.GetComponent<CharacterController2D>().c_pack = true;
            game = gamstatus.onbaging;

            Instantiate(pack).name = "P_pack";
            tsf = GameObject.Find("itemcreat");
            creatitem();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && game == gamstatus.onbaging)
        {
            this.gameObject.GetComponent<CharacterController2D>().c_pack = false;
            game = gamstatus.onplaying;

            Destroy(GameObject.Find("P_pack"));
        }
    }

    public void creatitem()
    {
        foreach (string item in bg.I_name)
        {
            foreach (GameObject s in itemdata)
            {
                if (s.name == item)
                {
                    Instantiate(s, tsf.transform);
                }
            }
        }
    }
    void showbag()
    {
        foreach (string i in bg.I_name)
            print(i);
    }
    void selected()
    {
        if (bg.I_name.Contains(_itemname) == true)
        {
            int num = bg.I_name.IndexOf(_itemname);
            bg.I_num[num]++;
        }
        else if (bg.I_name.Contains(_itemname) == false)
        {
            bg.I_name.Add(_itemname);
            bg.I_num.Add(1);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.C) && other.tag == "I_Potion")
        {
            _itemname = other.GetComponent<I_Potion>().o_name;
            selected();
            Destroy(other.gameObject);
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
public enum gamstatus
{
    onplaying,
    onbaging,
    oncompositing
}
