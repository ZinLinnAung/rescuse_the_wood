using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// follow camera to the player and make background feel real
/// </summary>
public class camera_controll : MonoBehaviour
{
    public static camera_controll instant;

    private void Awake()
    {
        instant = this;
    }
    //define variable for target,middle background and far background
    public Transform target,farbackground,middlebackground;
    //last position
    Vector2 lastX;
    //minimun and maximum scale of camera
    public float min = -0.1f;
    public float max = 1.2f;
    public bool stopfollow;


    private void Start()
    {
        //assign the last position
        lastX = transform.position;
    }

    void Update()
    {
        if (!stopfollow)
        {


            //allow the camera to move with player's x axis ,clamp the y axis with min and max position 
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, min, max), transform.position.z);
            //make the backgrounds feel real
            Vector2 amount = new Vector2(transform.position.x - lastX.x, transform.position.y - lastX.y);
            farbackground.position += new Vector3(amount.x, amount.y, 0);
            middlebackground.position += new Vector3(amount.x, amount.y, 0) * 0.5f;
            lastX = transform.position;
        }
    }
}
