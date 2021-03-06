﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    
    public float speed, jumpspeed;
    private Rigidbody2D Rigidbody;
    private Collider2D Collider;
    public float speed_X;

    public bool isGrounded;
    public LayerMask groundLaters;

    public bool isHided;
    public LayerMask hideLayers;

    public Animator playerAni;
    public Transform playerS;

    bool CrouchDown = false;
    /*----------------------------------------------------------------------------------------*/
    private Backpacage Pack;
    public bool c_pack = false;
    void Start()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        Pack = GameObject.Find("Contoller").GetComponent<Backpacage>();
        playerAni = GetComponent<Animator>();
    }

    void Update()
    {
        if (c_pack == false)
        {
            bool Walk = false;
            CrouchDown = false;

            // isground
            isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.3f, transform.position.y - 1.0f), new Vector2(transform.position.x + 0.3f, transform.position.y - -1.1f), groundLaters);

            // ishide
            isHided = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.3f, transform.position.y), new Vector2(transform.position.x + 0.3f, transform.position.y), hideLayers);


            if (Input.GetKey(KeyCode.RightArrow) && isGrounded == true)
            {
                Walk = true;

                playerS.localScale = new Vector2(0.1f, 0.1f);

                this.gameObject.transform.localScale = new Vector3(0.1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
                Rigidbody.AddForce(new Vector2(20 * speed, 0), ForceMode2D.Impulse);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && isGrounded == true)
            {
                Walk = true;

                playerS.localScale = new Vector2(-0.1f, 0.1f);

                this.gameObject.transform.localScale = new Vector3(-0.1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
                Rigidbody.AddForce(new Vector2(-20 * speed, 0), ForceMode2D.Impulse);
            }

            if (Walk)
            {
                if (playerAni.GetInteger("Walk") == 0)
                    playerAni.SetInteger("Walk", 1);
            }
            else
            {
                if (playerAni.GetInteger("Walk") == 1)
                    playerAni.SetInteger("Walk", 0);
            }

            // Hide
            if (Input.GetKeyDown(KeyCode.DownArrow) && isHided == true)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && isHided == true)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }

            // 速度限制
            if (Rigidbody.velocity.x > speed_X)
            {
                Rigidbody.velocity = new Vector2(speed_X, Rigidbody.velocity.y);
            }
            else if (Rigidbody.velocity.x < -speed_X)
            {
                Rigidbody.velocity = new Vector2(-speed_X, Rigidbody.velocity.y);
            }
            run();
            jump();
            unhitch();
            crouchDown();
        }        
    }

    void run()
    {
        bool Run = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed_X = 12;
            Run = true;
        }
        else
        {
            speed_X = 8;
        }

        if (Run)
        {
            if (playerAni.GetInteger("Run") == 0)
                playerAni.SetInteger("Run", 1);
        }
        else
        {
            if (playerAni.GetInteger("Run") == 1)
                playerAni.SetInteger("Run", 0);
        }
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerAni.SetBool("JumpUp", true);
            Rigidbody.AddForce(new Vector2(0, jumpspeed), ForceMode2D.Impulse);
        }
        else
        {
            playerAni.SetBool("JumpUp", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow) && isGrounded == true)
        {
            playerAni.SetBool("Jump", true);
            speed_X = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow) && isGrounded == true)
        {
            playerAni.SetBool("Jump", true);
            speed_X = 0f;
        }
        else
        {
            playerAni.SetBool("Jump", false);
            speed_X = 8.0f;
        }

    }

    void crouchDown()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            CrouchDown = true;
            speed_X = 0f;
        }

        if (CrouchDown)
        {
            if (playerAni.GetInteger(" CrouchDown") == 0)
                playerAni.SetInteger(" CrouchDown", 1);
        }
        else
        {
            if (playerAni.GetInteger(" CrouchDown") == 1)
                playerAni.SetInteger(" CrouchDown", 0);
            speed_X = 8.0f;
        }
    }
    void unhitch()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow) && isGrounded == true)
        {
            Rigidbody.AddForce(new Vector2(-(speed_X - 1.5f), 0), ForceMode2D.Impulse);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && isGrounded == true)
        {
            Rigidbody.AddForce(new Vector2(speed_X - 1.5f, 0), ForceMode2D.Impulse);
        }
    }
}


    
