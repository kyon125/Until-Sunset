using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player, f_camera;
    public float distanceA , distanceB;
    private float _distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _distance =f_camera.transform.position.x - player.transform.position.x;
        if (_distance <= distanceA)
        {
            f_camera.transform.position = new Vector3(player.transform.position.x + distanceA, f_camera.transform.position.y, f_camera.transform.position.z);
        }
        else if (Mathf.Abs(_distance) >= distanceB)
        {
            f_camera.transform.position = new Vector3(player.transform.position.x + distanceB, f_camera.transform.position.y, f_camera.transform.position.z);
        }
    }
}
