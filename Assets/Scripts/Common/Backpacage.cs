using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Backpacage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pack ;
    public GameObject [] ITEM;
    private GameObject Item;
    private itemval i_pack = new itemval();
    string n_item;
    void Start()
    {
        i_pack.id = new string[20];
        i_pack.num = new int[20];
        initial();

        string JSON = JsonUtility.ToJson(i_pack);
        Debug.Log(JSON);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initial()
    {
        StreamReader read = new StreamReader(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "backpack.json"));
        string load = read.ReadToEnd();
        read.Close();
        i_pack = JsonUtility.FromJson<itemval>(load);

        //string JSON = JsonUtility.ToJson(I_pack); ;
        //StreamWriter writer = new StreamWriter(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "backpack.json"));
        //writer.Write(JSON);
        //writer.Close();
    }
    public void readitem()
    {
        packset();
    }
    public void getitem()
    {
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                Item = Instantiate(ITEM[0], GameObject.Find("I0").transform);
                select();
                //print("紅藥水");
                break;
            case 1:
                Item = Instantiate(ITEM[1], GameObject.Find("I0").transform);                             
                select();
                //print("藍藥水");
                break;
        }
        save();
    }
    public void select()
    {
        n_item = Item.GetComponent<Itemset>().o_name;
        print(n_item  + "haha");
        for (int i = 0; i <= i_pack.id.Length - 1; i++)
        {

            if (i_pack.id[i] == n_item)
            {
                print("已擁有");
                i_pack.id[i] = n_item;
                i_pack.num[i]++;
                break;
            }
            else if (i == i_pack.id.Length -1 && i_pack.id[i] != n_item)
            {
                print("無相同");
                for (int a = 0; a < i_pack.id.Length; a++)
                {                    
                    if (i_pack.id[a] == "")
                    {                        
                        i_pack.id[a] = n_item;                        
                        i_pack.num[a]++;
                        break;
                    }                    
                }                
            }
        }
    }
    void packset()
    {
        for (int i = 0; i <= i_pack.id.Length - 1; i++)
        {
            for (int a = 0; a <= ITEM.Length - 1; a++)
            {
                if (i_pack.id[i] == ITEM[a].name)
                {
                    print(ITEM + ITEM[a].name);
                    Instantiate(ITEM[a], GameObject.Find("I" + i).transform);
                    break;
                }
            }
        }
    }
    public void close()
    {       
        Destroy(this.gameObject);
    }
    public void open()
    {
        Instantiate(pack);
    }
    void save()
    {
        string JSON = JsonUtility.ToJson(i_pack);
        StreamWriter writer = new StreamWriter(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "backpack.json"));
        writer.Write(JSON);
        writer.Close();
        Debug.Log(JsonUtility.ToJson(i_pack));
    }
}

public class itemval
{
    public string [] id;
    public int [] num;
}

