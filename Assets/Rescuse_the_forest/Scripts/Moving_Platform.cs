using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public Transform[] points;
    public float movingspeed;
    public int currentpoint;
    public Transform Platform;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Platform.position = Vector3.MoveTowards(Platform.position, points[currentpoint].position, movingspeed * Time.deltaTime);

        if(Vector3.Distance(Platform.position,points[currentpoint].position)<0.5f)
        {
            currentpoint++;
            if(currentpoint>=points.Length)
            {
                currentpoint = 0;
            }
        }
    }
}
