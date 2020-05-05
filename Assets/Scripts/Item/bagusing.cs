using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class bagusing : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerBag player;
    public GameObject com;    
    private gamstatus game;
    string n_tag ;
    void Start()
    {        
        player = GameObject.FindWithTag("Player").GetComponent<PlayerBag>();        
    }

    // Update is called once per frame
    void Update()
    {
        game = GameObject.FindWithTag("Player").GetComponent<PlayerBag>().game;
    }
    public void useitem()
    {
        if (game == gamstatus.onbaging)
        {
            n_tag = this.gameObject.tag;
            switch (n_tag)
            {
                case "I_Potion":
                    {
                        int num = player.bg.I_name.IndexOf(this.gameObject.GetComponent<I_Potion>().o_name);
                        player.bg.I_num[num]--;
                        print(player.bg.I_num[num]);
                        if (player.bg.I_num[num] == 0)
                        {
                            Destroy(this.gameObject);
                            player.bg.I_name.RemoveAt(num);
                            player.bg.I_num.RemoveAt(num);
                        }
                        break;
                    }

            }
        }
        else if (game == gamstatus.oncompositing)
        {
            int num = player.bg.I_name.IndexOf(this.gameObject.GetComponent<I_Potion>().o_name);
            foreach (GameObject s in player.itemdata)
            {
                if (s.name == this.gameObject.GetComponent<I_Potion>().o_name)
                {
                    if (player.comitem.Count < 2)
                    {
                        player.comitem.Add(s);
                        Instantiate(s, GameObject.Find("ct").transform);
                        break;
                    }                    
                }                
            }
        }
        else
        {
            
        }
    }
    public void close()
    {
        switch (game)
        {
            case gamstatus.onbaging:
                {
                    Destroy(GameObject.Find("P_pack"));
                    player.game = gamstatus.onplaying;                    
                    break;
                }
            case gamstatus.oncompositing:
                {
                    player.comitem.Clear();
                    player.game = gamstatus.onbaging;
                    Destroy(GameObject.Find("P_com"));
                    break;
                }
        }
    }
    public void B_composite()
    {        
        switch (game)
        {
            case gamstatus.onbaging:
                {
                    player.game = gamstatus.oncompositing;
                    Instantiate(com).name = "P_com";
                    print(game);
                    break;
                }
            case gamstatus.oncompositing:
                {
                    break;
                }
        }             
    }
    public void composite()
    {
        if (player.comitem.Contains(player.itemdata[0]) && player.comitem.Contains(player.itemdata[1]))
        {
            if (player.bg.I_name.Contains(player.itemdata[2].name) == true)
            {
                int num = player.bg.I_name.IndexOf(player.itemdata[2].name);
                player.bg.I_num[num]++;
            }
            else if (player.bg.I_name.Contains(player.itemdata[2].name) == false)
            {
                player.bg.I_name.Add(player.itemdata[2].name);
                player.bg.I_num.Add(1);
                Instantiate(player.itemdata[2], GameObject.Find("itemcreat").transform);
            }
        }
        else
        {
            for (int i = 0; i < GameObject.Find("ct").transform.childCount; i++)
            {
                GameObject go = GameObject.Find("ct").transform.GetChild(i).gameObject;
                Destroy(go);
            }
        }
        
        for (int i = 0; i < GameObject.Find("ct").transform.childCount; i++)
        {
            GameObject go = GameObject.Find("ct").transform.GetChild(i).gameObject;
            Destroy(go);
        }
        player.comitem.Clear();
    }
}

