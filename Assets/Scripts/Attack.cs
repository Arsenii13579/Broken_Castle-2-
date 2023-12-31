using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;

    public float attackTime;
    public float startTimeAttack;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if( attackTime <= 0 )
        {
            if(Input.GetMouseButtonDown(0))
            {
                anim.SetBool("attack", true);
                Collider2D[] damage = Physics2D.OverlapCircleAll( attackLocation.position, attackRange, enemies);
                for (int i = 0; i < damage.Length; i++)
                {
                    Destroy( damage[i].gameObject );
                }
                attackTime = startTimeAttack;
            }
        }
        else
        {
            anim.SetBool("attack", false);
            attackTime -= Time.deltaTime;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}
