using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAi : MonoBehaviour
{
    public enum Status { idle, chase };
    public Status status;

    public enum Face { Right, Left };
    public Face face;

    public float speed;
    private Transform monster;
    private SpriteRenderer spr;

    public Transform player;
    public Transform obstacle;
    private float timerF = 0f;
    private float timerI = 0;

    // Start is called before the first frame update
    void Start()
    {
        status = Status.idle;
        spr = this.transform.GetComponent<SpriteRenderer>();

        if (spr.flipX)
        {
            face = Face.Left;
        }
        else
        {
            face = Face.Right;
        }
        monster = this.transform;
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        float dTime = Time.deltaTime;
        switch (status)
        {
            case Status.idle:
                if (Mathf.Abs(monster.position.x - player.position.x) < 5 && Mathf.Abs(monster.position.y - player.position.y) < 2)
                {
                    status = Status.chase;
                }
                break;
            case Status.chase:
                if (monster.position.x >= player.position.x)
                {
                    spr.flipX = false;
                    face = Face.Left;
                }
                else
                {
                    spr.flipX = true;
                    face = Face.Right;
                }
                switch (face)
                {
                    case Face.Left:
                        transform.position -= new Vector3(speed * dTime, 0, 0);
                        break;
                    case Face.Right:
                        transform.position += new Vector3(speed * dTime, 0, 0);
                        break;
                }
                if (Mathf.Abs(monster.position.x - player.position.x) >= 6)
                {
                    status = Status.idle;
                }
                else if (Mathf.Abs(monster.position.x - player.position.x) > Mathf.Abs(monster.position.x - obstacle.position.x))
                {
                    if (timerI >= 5)
                    {
                        status = Status.idle;
                        timerI = 0;
                    }
                }
                break;

        }
    }

    void Timer()
    {
        timerF += Time.deltaTime;
        timerI = (int)timerF;
    }
}
