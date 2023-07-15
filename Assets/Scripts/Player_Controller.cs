using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Rigidbody2D rb;
    public float Impuls = 10; //
    public float DashTime = 2f; //
    float currentDashTime;

    Vector3 pos; //
    Camera main; //

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        main = FindObjectOfType<Camera>(); //
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        direction = new Vector2(direction.x, direction.y).normalized; //

        pos = main.WorldToScreenPoint(transform.position); //
        Flip(); //

        if (Input.GetKey(KeyCode.LeftShift)) //
        {
            speed = 5f;
            //direction = direction * Impuls;
        }

        else
        {
            speed = 3f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
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
}
