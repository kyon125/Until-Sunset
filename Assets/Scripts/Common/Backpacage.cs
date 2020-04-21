using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class Backpacage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pack,u1,u2,u3;
    public GameObject[] ITEM;
    public itemval i_pack = new itemval();
    public string n_item;

    private GameObject [] u_item;
    private int u_itemnum = 0;
    private bool selectopen = false;
    int n1, n2 = 0, n3;
    void Start()
    {
        i_pack.id = new string[20];
        i_pack.num = new int[20];
        u_item = new GameObject[20];
        initial();

        string JSON = JsonUtility.ToJson(i_pack);
        Debug.Log(JSON);
    }

    // Update is called once per frame
    void Update()
    {
        //CU_select();
        //d_cleanbag();
    }

    void initial()
    {
        StreamReader read = new StreamReader(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "backpack.json"));
        string load = read.ReadToEnd();
        read.Close();
        i_pack = JsonUtility.FromJson<itemval>(load);
    }
    public void select()
    {
        print(n_item + "haha");
        for (int i = 0; i <= i_pack.id.Length - 1; i++)
        {

            if (i_pack.id[i] == n_item)
            {
                print("已擁有");
                i_pack.id[i] = n_item;
                i_pack.num[i]++;
                break;
            }
            else if (i == i_pack.id.Length - 1 && i_pack.id[i] != n_item)
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

    public void close()
    {
        Destroy(GameObject.FindWithTag("pack"));
    }
    public void open()
    {
        Instantiate(pack);
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
    public void save()
    {
        string JSON = JsonUtility.ToJson(i_pack);
        StreamWriter writer = new StreamWriter(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "backpack.json"));
        writer.Write(JSON);
        writer.Close();
        Debug.Log(JsonUtility.ToJson(i_pack));
    }

    private void d_cleanbag()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            print("aaaa");
            for (int a = 0; a < i_pack.id.Length; a++)
            {
                i_pack.id[a] = "";
                i_pack.num[a] = 0;
            }
            string JSON = JsonUtility.ToJson(i_pack);
            StreamWriter writer = new StreamWriter(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "backpack.json"));
            writer.Write(JSON);
            writer.Close();
            Debug.Log(JsonUtility.ToJson(i_pack));
        }
    }
    
    private void CU_select()
    {        
        if (Input.GetKeyDown(KeyCode.E) && selectopen == false)
        {
            selectopen = true;
            U_intial();
        }
        else if (Input.GetKeyDown(KeyCode.E) && selectopen == true)
        {
            selectopen = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && selectopen == true)
        {
            u_itemnum++;
            if (u_item[u_itemnum] != null)
            {
                u_item[u_itemnum].GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                u_item[u_itemnum - 1].GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
                for (int a = 0; a < u_item.Length; a++)
                {
                    if (u_item[a] == null)
                        break;
                    u_item[a].transform.position = new Vector3(u_item[a].transform.position.x - 80, u_item[a].transform.position.y, u_item[a].transform.position.z);
                }
            }
            else if (u_item[u_itemnum] == null)
            {
                u_item[u_itemnum-1].GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
                for (int a = 0; a < u_item.Length; a++)
                {
                    if (u_item[a] == null)
                        break;
                    u_item[a].transform.position = new Vector3(u_item[a].transform.position.x + 80 * (u_itemnum-1), u_item[a].transform.position.y, u_item[a].transform.position.z);
                }
                u_itemnum = 0;
                u_item[u_itemnum].GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
            }            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && selectopen == true)
        {
            u_itemnum--;
            if (u_itemnum < 0)
            {
                for (int a = 0; a < u_item.Length; a++)
                {
                    if (u_item[a] == null)
                    {
                        u_itemnum = a - 1;
                        break;
                    }                    
                }
                for (int a = 0; a < u_item.Length; a++)
                {
                    if (u_item[a] == null)
                    {
                        break;
                    }
                    u_item[a].transform.position = new Vector3(u_item[a].transform.position.x - 80 * (u_itemnum), u_item[a].transform.position.y, u_item[a].transform.position.z);
                }
                u_item[0].GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
                u_item[u_itemnum].GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
            }
            else
            {
                u_item[u_itemnum].GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                u_item[u_itemnum + 1].GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
                for (int a = 0; a < u_item.Length; a++)
                {
                    if (u_item[a] == null)
                        break;
                    u_item[a].transform.position = new Vector3(u_item[a].transform.position.x + 80, u_item[a].transform.position.y, u_item[a].transform.position.z);
                }
            }
        }
    }
    private void U_intial()
    {
        int a = 0, c = 0;
        for (int i = 0; i < i_pack.id.Length; i++)
        {
            for (int b = 0; b < ITEM.Length; b++)
            {
                if (ITEM[b].name == i_pack.id[i])
                {
                    u_item[c] = Instantiate(ITEM[b], new Vector3(u2.transform.position.x + a, u2.transform.position.y, u2.transform.position.z), Quaternion.identity, u2.transform);
                    c++;
                    a = a + 80;
                    break;
                }
            }
        }
        u_item[u_itemnum].GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
    }
}

public class itemval
{
    public string [] id;
    public int [] num;
}

