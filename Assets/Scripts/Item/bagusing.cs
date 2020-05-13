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
    private GameStatus gameStatus;
    string n_tag ;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerBag>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void useitem()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        if (gameStatus.status == GameStatus.Status.onBaging)
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
        else if (gameStatus.status == GameStatus.Status.onComposition)
        {
            //int num = player.bg.I_name.IndexOf(this.gameObject.GetComponent<I_Potion>().o_name);
            //foreach (GameObject s in player.itemdata)
            //{
            //    if (s.name == this.gameObject.GetComponent<I_Potion>().o_name)
            //    {
            //        if (player.comitem.Count < 2)
            //        {
            //            player.comitem.Add(s);
            //            Instantiate(s, GameObject.Find("ct").transform);
            //            break;
            //        }                    
            //    }                
            //}
            int num = player.bg.I_name.IndexOf(this.gameObject.GetComponent<Itemset>().o_name);
            foreach (GameObject s in player.itemdata)
            {
                if (s.name == this.gameObject.GetComponent<Itemset>().o_name)
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
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        switch (gameStatus.status)
        {
            case GameStatus.Status.onBaging:
                {
                    Destroy(GameObject.Find("P_pack"));
                    gameStatus.status = GameStatus.Status.onPlaying;                    
                    break;
                }
            case GameStatus.Status.onComposition:
                {
                    player.comitem.Clear();
                    gameStatus.status = GameStatus.Status.onBaging;
                    Destroy(GameObject.Find("P_com"));
                    break;
                }
        }
    }
    public void B_composite()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        switch (gameStatus.status)
        {
            case GameStatus.Status.onBaging:
                {
                    gameStatus.status = GameStatus.Status.onComposition;
                    Instantiate(com).name = "P_com";
                    print(gameStatus.status);
                    break;
                }
            case GameStatus.Status.onComposition:
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

