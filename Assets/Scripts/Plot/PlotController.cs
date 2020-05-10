using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotController : MonoBehaviour
{
    // Start is called before the first frame update
    List<Plotclass> plot = new List<Plotclass>();
    void Start()
    {
        initial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initial()
    {
        TextAsset data = Resources.Load<TextAsset>("plot");

        string [] p = data.text.Split(new char[] { '\n' });

        for (int a = 0; a < p.Length - 1; a++)
        {
            string [] row = p[a].Split(new char [] { ','});

            Plotclass step = new Plotclass();
            step.id = row[0];
            step.target = row[1];
            step.content = row[2];

            plot.Add(step);
        }
    }
}
