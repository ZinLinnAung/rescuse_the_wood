using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collector_effect : MonoBehaviour
{
    public float lifetime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
