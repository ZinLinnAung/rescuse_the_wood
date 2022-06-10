using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public static player_controller instant;

    public float speed = 5f;
    public Rigidbody2D rb;
    public float Jumpforce = 7f;
    public LayerMask mask;
    public Transform groundpoint;
    private bool candoublejump;
    public SpriteRenderer rander;
    public Animator animator;
    public float knockback_length,knockback_force;
    public float knockback_counter;
    public float bounce_force;
    public bool stop_input;

    private void Awake()
    {
        instant = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rander = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        

    }

    
    void Update()
    {
        if (!PauseMenu.instance.ispause && !stop_input)
        {
            if (knockback_counter <= 0)
            {
                bool isgrounded = Physics2D.OverlapCircle(groundpoint.position, 0.3f, mask);
                float input = Mathf.Abs(Input.GetAxisRaw("Horizontal") * speed);
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

                if (isgrounded)
                {
                    candoublejump = true;
                    animator.SetBool("jump", false);
                    animator.SetBool("inair", false);

                }
                else
                {

                    animator.SetBool("inair", true);
                }
                if (rb.velocity.x < 0)
                {
                    rander.flipX = true;
                }
                else if (rb.velocity.x > 0)
                {
                    rander.flipX = false;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (isgrounded)
                    {
                        Audio_manager.instance.PlaySFX(10);
                        animator.SetBool("jump", true);
                        rb.velocity = new Vector2(rb.velocity.x, Jumpforce);


                    }
                    else if (candoublejump)
                    {
                        Audio_manager.instance.PlaySFX(10);
                        animator.SetBool("jump", true);
                        rb.velocity = new Vector2(rb.velocity.x, Jumpforce);
                        candoublejump = false;


                    }

                }
                if (rb.velocity.y < 8f)
                {
                    animator.SetBool("jump", false);
                }


                animator.SetFloat("speed", input);
            }
            else
            {
                knockback_counter -= Time.deltaTime;
                if (!rander.flipX)
                {
                    rb.velocity = new Vector2(-knockback_force, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(knockback_force, rb.velocity.y);
                }
            }

        }

    }
    public void knockback()
    {
        knockback_counter = knockback_length;
        rb.velocity = new Vector2(0f, knockback_force);
        animator.SetTrigger("hurt");

    }
    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, bounce_force);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("platform"))
        {
            transform.parent = other.transform;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            transform.parent = null;
        }
    }
}
