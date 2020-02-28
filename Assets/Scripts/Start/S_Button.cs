using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void p_start()
    {
        SceneManager.LoadScene("Demo");
    }
    public void p_end()
    {
        Application.Quit();
    }
}
