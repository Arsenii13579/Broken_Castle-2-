using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 moveVector;

    Vector3 pos; //
    Camera main; //

    //public bool FaceRight = true; //
    
    public int lungeImpulse = 5000; 

    private void Start() //
    {
        main = FindObjectOfType<Camera>();
    } 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        moveVector = new Vector2(moveVector.x, moveVector.y).normalized; //

        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //

        //reflect();
        //Lunge();

        pos = main.WorldToScreenPoint(transform.position); //
        Flip(); //
    }

    void Flip() //
    {
        if(Input.mousePosition.x < pos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if(Input.mousePosition.x > pos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }


    //void reflect()//
    //{
    //    if((moveVector.x > 0 && !FaceRight) || (moveVector.x < 0 && FaceRight))
        //if(Player.position > mousePosition)
    //    {
    //        transform.localScale *= new Vector2(-1, 1);
    //        FaceRight = !FaceRight;

    //    }
    //}

    //void Lunge()
    //{
    //    if(Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        rb.velocity = new Vector2(0, 0);

    //        if(!FaceRight)
    //        {
    //            rb.AddForce(new Vector2(-lungeImpulse, 0), ForceMode2D.Impulse);
    //        }

    //        else
    //        {
    //            rb.AddForce(new Vector2(lungeImpulse, 0), ForceMode2D.Impulse);
    //        }
    //    }
    //}

}