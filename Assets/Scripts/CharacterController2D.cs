using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    public float speed , jumpspeed;
    private Rigidbody2D Rigidbody;
    private Collider2D Collider; 
    public float speed_X;
   
    public bool isGrounded;
    public LayerMask groundLaters;

    public bool isHided;
    public LayerMask hideLayers;

    /*----------------------------------------------------------------------------------------*/
    private Backpacage Pack;
    private bool c_pack;
    void Start()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        Pack = GameObject.Find("Contollner").GetComponent<Backpacage>();
    }

    void Update()
    {
        // isground
       isGrounded= Physics2D.OverlapArea(new Vector2(transform.position.x -0.3f, transform.position.y -1.0f), new Vector2(transform.position.x + 0.3f, transform.position.y - -1.1f), groundLaters);

        // ishide
        isHided= Physics2D.OverlapArea(new Vector2(transform.position.x -0.3f, transform.position.y), new Vector2(transform.position.x + 0.3f, transform.position.y),hideLayers);


        if (Input.GetKey(KeyCode.RightArrow) && isGrounded == true)  
        {
            this.gameObject.transform.localScale = new Vector3(0.1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            Rigidbody.AddForce(new Vector2(20 * speed, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Rigidbody.AddForce(new Vector2(0, jumpspeed), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && isGrounded == true)
        {
            this.gameObject.transform.localScale = new Vector3(-0.1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            Rigidbody.AddForce(new Vector2(-20 * speed, 0), ForceMode2D.Impulse);
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
        unhitch();
        callpack();
    }

    void callpack()
    {
        if (Input.GetKeyDown(KeyCode.Return) && c_pack == false)
        {
            c_pack = true;
            Pack.open();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && c_pack == true)
        {
            c_pack = false;
            Pack.close();
        }
    }
    void unhitch()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow) && isGrounded == true)
        {            
            Rigidbody.AddForce(new Vector2(-(speed_X-1.5f), 0), ForceMode2D.Impulse);
        }        
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && isGrounded == true)
        {
            Rigidbody.AddForce(new Vector2(speed_X - 1.5f, 0), ForceMode2D.Impulse);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item" && Input.GetKeyDown(KeyCode.C))
        {
            Pack.n_item = collision.gameObject.GetComponent<Itemset>().o_name;
            Pack.select();
            Pack.save();
            Destroy(collision.gameObject);
            print(Pack.n_item);
        }            
    }     
}
