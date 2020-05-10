using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using DG.Tweening;

public class WellPlot1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        plot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        plot();
    }
    void plot()
    {
        for (int a = 0; a < 10; a++)
        {
            print(a);
        }
        //yield return null;        
    }
}
