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
    private GameStatus gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        bg.I_name = new List<string>();
        bg.I_num = new List<int>();
        comitem = new List<GameObject>();

        de_item();
    }

    // Update is called once per frame
    void Update()
    {
        callpack();
    }
    protected void callpack()
    {
        if (Input.GetKeyDown(KeyCode.Return) && gameStatus.status == GameStatus.Status.onPlaying)
        {            
            gameStatus.status = GameStatus.Status.onBaging;

            Instantiate(pack).name = "P_pack";
            tsf = GameObject.Find("itemcreat");
            creatitem();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && gameStatus.status == GameStatus.Status.onBaging)
        {
            gameStatus.status = GameStatus.Status.onPlaying;

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
        if (Input.GetKeyDown(KeyCode.C) && other.tag =="item")
        {
            _itemname = other.GetComponent<Itemset>().o_name;
            selected();
            Destroy(other.gameObject);
        }
    }

    private void de_item()
    {
        bg.I_name.Add("打火石");
        bg.I_num.Add(1);
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

