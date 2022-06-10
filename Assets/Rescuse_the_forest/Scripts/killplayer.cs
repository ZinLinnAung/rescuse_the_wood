using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killplayer : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Instantiate(player_health_control.instant.deadeffect, other.transform.position, other.transform.rotation);
            level_manager.instant.RespawnPlayer();
        }
    }
}
