using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform Player;

    public float speed;
    public float agroDistance;

    public int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform. position, Player.position);

        if(distToPlayer < agroDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.fixedDeltaTime);
        }
        //else
        //{
            
        //}
    }
}
