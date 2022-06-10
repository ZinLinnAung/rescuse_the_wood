using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    
    public SpriteRenderer SR;
    public Sprite checkpoint_off, checkpoint_on;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            checkpoint_controller.instant.DeativateCheckPoint();
            SR.sprite = checkpoint_on;
            checkpoint_controller.instant.SpawnPoint(transform.position);
        }
    }

    public void restartcheckpoint()
    {
        SR.sprite = checkpoint_off;
    }
}
