using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{

    public GameObject player; // 玩家
    public float angle = 60f; // 角度
    public GameObject bullet; // 子彈
    public Transform rayPic;
    public Transform rayPic0;
    public float power = 500f;

    // Start is called before the first frame update
    void Start()
    {
        rayPic.eulerAngles = new Vector3(0, 0, angle);
        rayPic0.eulerAngles = new Vector3(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {
        shootControllor();
    }

    private void shootControllor()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            shoot(power);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (player)
            {
                angle += 0.5f;
                angle = angle % 360;
            }
            else
            {
                angle -= 0.5f;
                angle = angle % 360;
            }
            rayPic.eulerAngles = new Vector3(0, 0, angle);
            rayPic0.eulerAngles = new Vector3(0, 0, angle);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!player)
            {
                angle += 0.5f;
                angle = angle % 360;
            }
            else
            {
                angle -= 0.5f;
                angle = angle % 360;
            }
            rayPic.eulerAngles = new Vector3(0, 0, angle);
            rayPic0.eulerAngles = new Vector3(0, 0, angle);
        }
    }

    private void shoot(float power)
    {
        GameObject _bullet = Instantiate(bullet, player.transform.position, Quaternion.identity) as GameObject;
        Vector2 forceDir = new Vector2(Mathf.Cos(Mathf.PI * angle / 180), Mathf.Sin(Mathf.PI * angle / 180));
        _bullet.GetComponent<Rigidbody2D>().AddForce(forceDir * power);
    }
}
