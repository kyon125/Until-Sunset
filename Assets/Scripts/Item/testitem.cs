using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testitem : MonoBehaviour
{
    // Start is called before the first frame update
    List<Itemclass> item = new List<Itemclass>();
    void Start()
    { 
        TextAsset itemdata = Resources.Load<TextAsset>("database");

        string[] data = itemdata.text.Split(new char[] { '\n' });

        for (int a = 0; a < data.Length - 1; a++)
        {
            string[] row = data[a].Split(new char[] { ',' });

            Itemclass i = new Itemclass();
            i.id = row[0];
            i.name = row[1];

            item.Add(i);
        }

        //foreach (Itemclass p in item)
        //{
        //    Debug.Log(p.id);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
