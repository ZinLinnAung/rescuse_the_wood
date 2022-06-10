using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot_hit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dead_effect;
    public float chanceToDrop;
    public GameObject collectable;
    public bool bouncePlayer=false;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            float chance = Random.Range(0, 100);

            Instantiate(dead_effect, collision.transform.position, collision.transform.rotation);
            collision.transform.parent.gameObject.SetActive(false);
            if(chance<=chanceToDrop)
            {
                Instantiate(collectable, collision.transform.position, collision.transform.rotation);
            }
            Audio_manager.instance.PlaySFX(3);

            if (bouncePlayer)
            {
                player_controller.instant.Bounce();
            }

            Destroy(collision.gameObject);
            
        }
        
    }
}
