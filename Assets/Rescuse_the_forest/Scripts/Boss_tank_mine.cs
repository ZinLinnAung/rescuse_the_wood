using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_tank_mine : MonoBehaviour
{

    public GameObject explosion;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Explose();
            Audio_manager.instance.PlaySFX(3);
            player_health_control.instant.dealDamage();

        }
    }

    public void Explose()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
