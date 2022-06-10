using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_player : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            player_health_control.instant.dealDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="Player")
        {

            player_health_control.instant.dealDamage();
            
        }
    }
}
