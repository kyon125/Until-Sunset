using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Backpacage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pack;
    public GameObject [] ITEM;
    private itemval i_pack = new itemval();
    void Start()
    {
        i_pack.id = new string[2];
        i_pack.num = new int[2];        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initial()
    {
        //StreamReader read = new StreamReader(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "backpack.json"));
        //string load = read.ReadToEnd();
        //read.Close();
        //I_pack = JsonUtility.FromJson<item>(load);

        //string JSON = JsonUtility.ToJson(I_pack); ;
        //StreamWriter writer = new StreamWriter(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "backpack.json"));
        //writer.Write(JSON);
        //writer.Close();
    }
    public void readitem()
    {
        Debug.Log(JsonUtility.ToJson(i_pack));
        //StreamReader read = new StreamReader(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "backpack.json"));
        //string load = read.ReadToEnd();
        //read.Close();
        //i_pack = JsonUtility.FromJson<itemval>(load);      
    }
    public void getitem()
    {
        int random = Random.Range(0, 2);        
        GameObject Item = new GameObject();        

        switch (random)
        {
            case 0:
                Item = Instantiate(ITEM[0], GameObject.Find("I0").transform);
                print("紅藥水");
                break;
            case 1:
                Item = Instantiate(ITEM[1], GameObject.Find("I0").transform);
                print("藍藥水");
                break;
        }

        string n_item = Item.GetComponent<Itemset>().o_name;

        for (int i =0; i <= i_pack.id.Length -1; i++)
        {
            print(i_pack.id.Length);
            if (i_pack.id[i] == n_item)
            {
                print("已擁有");
                i_pack.id[i] = n_item;
                i_pack.num[i]++;
                break;
            }
            else if (i == i_pack.id.Length && i_pack.id[i] != n_item)
            {
                print("無相同");
                for (int a = 0; a < i_pack.id.Length; a++)
                {
                    if (i_pack.id[a] == null)
                    {
                        i_pack.id[a] = n_item;
                        i_pack.num[a]++;
                    }
                }
                break;
            }
        }      
        //string JSON = JsonUtility.ToJson(i_pack);
        //StreamWriter writer = new StreamWriter(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "backpack.json"));
        //writer.Write(JSON);
        //writer.Close();

        //Debug.Log(JSON);
    }
    public void close()
    {        
        Destroy(this.gameObject);
    }
    public void open()
    {
        Instantiate(pack);
    }
}

public class itemval
{
    public string [] id;
    public int [] num;
}

