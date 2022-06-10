using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable_item : MonoBehaviour
{
    public bool isgen;
    public bool isheal;
    public bool iscollected;
    public GameObject pickupeffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(isgen&&!iscollected)
            {
                level_manager.instant.countgen++;
                iscollected = true;
                Destroy(gameObject);
                Debug.Log(level_manager.instant.countgen);
                Audio_manager.instance.PlaySFX(6);
                Instantiate(pickupeffect, transform.position, transform.rotation);

                UI_controller.instant.updateUI();
            }
            if(isheal && !iscollected)
            {
                if (player_health_control.instant.current_health != player_health_control.instant.max_health)
                {
                    player_health_control.instant.current_health++;

                    UI_controller.instant.updateUI();
                    Audio_manager.instance.PlaySFX(7);
                    Instantiate(pickupeffect, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
    }
}
