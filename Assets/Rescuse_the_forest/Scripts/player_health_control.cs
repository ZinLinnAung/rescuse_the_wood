using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health_control : MonoBehaviour
{
    public static player_health_control instant;
    public float invisial_length;
    public float invisial_counter;
    public GameObject deadeffect;
    Renderer R;
    Color c;

    private void Awake()
    {
        instant = this;
    }

    public int current_health = 0;
    public int max_health = 6;
    void Start()
    {
        current_health = max_health;
        R = GetComponent<Renderer>();
        c = R.material.color;
       
    }

    
    void Update()
    {
        if(invisial_counter>0)
        {
            invisial_counter -= Time.deltaTime;
        }else 
        {
            c.a = 1f;
            R.material.color = c;
        }
    }

    public void dealDamage()
    {
        
        if (invisial_counter <= 0)
        {
            current_health--;
            Audio_manager.instance.PlaySFX(9);

            if (current_health <= 0)
            {
                
                current_health = 0;
                Instantiate(deadeffect, transform.position, transform.rotation);
                level_manager.instant.RespawnPlayer();
                //gameObject.SetActive(false);
            }else
            {
                invisial_counter = invisial_length;
                c.a = 0.5f;
                R.material.color = c;
                player_controller.instant.knockback();
                
                
            }
            
            UI_controller.instant.updateUI();
        }
       
    }
}
