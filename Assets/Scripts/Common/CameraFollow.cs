using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player, f_camera;
    public float distanceXA , distanceXB;
    public float distanceYA, distanceYB;
    private float _distanceX, _distanceY, Camerasize;
    private bool big = false;
    private GameObject MC;
    void Start()
    {
        f_camera.transform.position = new Vector3(player.transform.position.x , player.transform.position.y + 4, f_camera.transform.position.z);
        MC = GameObject.Find("Main_Camera");
    }

    // Update is called once per frame
    void Update()
    {
        cameraX();
        cameraY();
        //C_change();
    }
    void cameraX()
    {
        //print(_distanceX);
        _distanceX = f_camera.transform.position.x - player.transform.position.x;
        if (_distanceX <= distanceXA)
        {
            f_camera.transform.position = new Vector3(player.transform.position.x + distanceXA, f_camera.transform.position.y, f_camera.transform.position.z);
        }
        else if (Mathf.Abs(_distanceX) >= distanceXB)
        {
            f_camera.transform.position = new Vector3(player.transform.position.x + distanceXB, f_camera.transform.position.y, f_camera.transform.position.z);
        }
    }
    void cameraY()
    {
        if (big == false)
        {
            _distanceY = f_camera.transform.position.y - player.transform.position.y;
            f_camera.transform.position = new Vector3(f_camera.transform.position.x, player.transform.position.y + 8, f_camera.transform.position.z);
        }        
    }
    private void C_change()
    {        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            big = true;
            DOTween.To(() => MC.GetComponent<Camera>().orthographicSize, x => MC.GetComponent<Camera>().orthographicSize = x, 15, 0.5f);
            MC.transform.position = Vector3.Lerp(MC.transform.position, new Vector3(MC.transform.position.x, MC.transform.position.y + 8, MC.transform.position.z), 1.5F);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            DOTween.To(() => GameObject.Find("Main_Camera").GetComponent<Camera>().orthographicSize, x => GameObject.Find("Main_Camera").GetComponent<Camera>().orthographicSize = x, 6, 0.5f);
            big = false;           
        }        
    }
}
