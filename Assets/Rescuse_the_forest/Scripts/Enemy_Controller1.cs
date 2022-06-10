using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed;
    public Transform left_point, right_point;
    public Rigidbody2D rb;
    private bool moving_right;
    public SpriteRenderer Sr;
    private float movecount;
    public float movetime;
    public float stoptime;
    private float stopcount;
    public Animator animator;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        left_point.parent = null;
        right_point.parent = null;
        movecount = movetime;

    }

    // Update is called once per frame
    void Update()
    {
        if (movecount > 0)
        {
            movecount -= Time.deltaTime;
            if (moving_right)
            {
                rb.velocity = new Vector2(movespeed, rb.velocity.y);
                Sr.flipX = true;

                if (transform.position.x > right_point.position.x)
                {
                    moving_right = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-movespeed, rb.velocity.y);
                Sr.flipX = false;
                if (transform.position.x < left_point.position.x)
                {
                    moving_right = true;
                }
            }
            if(movecount<=0)
            {
                stopcount = stoptime;
            }
            animator.SetBool("Jump", true);
        }
        else if(stopcount>0)
        {
            animator.SetBool("Jump", false);
            
            stopcount -= Time.deltaTime;

            rb.velocity = new Vector2(0, rb.velocity.y);

            if (stopcount<=0)
            {

                
                movecount = movetime;
            }
        }
    }
}
