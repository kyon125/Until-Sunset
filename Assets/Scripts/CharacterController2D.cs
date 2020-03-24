using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    private float speed = 1.0f;
    private Rigidbody2D Rigidbody;
    private Collider2D Collider; 
    private float speed_X=5.0f;
   
    public bool isGrounded;
    public LayerMask groundLaters;

    public bool isHided;
    public LayerMask hideLayers;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // isground
       isGrounded= Physics2D.OverlapArea(new Vector2(transform.position.x -1.0f, transform.position.y -1.0f), new Vector2(transform.position.x + 1.0f, transform.position.y - 1.0f), groundLaters);

        //ishide
        isHided= Physics2D.OverlapArea(new Vector2(transform.position.x -1.0f, transform.position.y), new Vector2(transform.position.x + 1.0f, transform.position.y),hideLayers);


        if (Input.GetKey(KeyCode.D))
        {
            Rigidbody.AddForce(new Vector2(100 * speed, 0), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Rigidbody.AddForce(new Vector2(-100 * speed, 0), ForceMode2D.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) 
        {
            Rigidbody.AddForce(new Vector2(0, 30), ForceMode2D.Impulse);
        }

        // Hide
        if (Input.GetKeyDown(KeyCode.S) && isHided == true)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.W) && isHided == true)
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

    }
}
