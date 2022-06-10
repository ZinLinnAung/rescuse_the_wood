using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHItBox : MonoBehaviour
{
    public boss_tank_controller boss;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&& player_controller.instant.transform.position.y>transform.position.y)
        {
            player_controller.instant.Bounce();
            boss.TakeHit();
            gameObject.SetActive(false);
        }
    }
}
