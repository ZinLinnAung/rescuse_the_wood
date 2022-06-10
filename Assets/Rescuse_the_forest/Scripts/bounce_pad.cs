using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce_pad : MonoBehaviour
{
    public float bounce_high;
    public Animator animator;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if( other.CompareTag("Player"))
        {
           
            player_controller.instant.rb.velocity= new Vector2(player_controller.instant.rb.velocity.x, bounce_high);
            animator.SetTrigger("bounce");
        }
    }
}
