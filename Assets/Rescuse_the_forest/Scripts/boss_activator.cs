using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_activator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject theboss;
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
            theboss.SetActive(true);
            Audio_manager.instance.PlayBossMusic();
            gameObject.SetActive(false);
        }
    }
}
