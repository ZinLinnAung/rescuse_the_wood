using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject swichtoObject;
    public SpriteRenderer SR;
    public Sprite downswitch;
    private bool hasSwitched;
    public bool DeativatedOnSwitch;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        if (DeativatedOnSwitch)
        {
            swichtoObject.SetActive(true);
        }
        else
        {
            swichtoObject.SetActive(false);
        }
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if( other.CompareTag("Player")&& !hasSwitched)
        {
            if(DeativatedOnSwitch)
            {
                swichtoObject.SetActive(false);
            }else
            {
                swichtoObject.SetActive(true);
            }
            
            SR.sprite = downswitch;
            hasSwitched = true;
        }
    }
}
