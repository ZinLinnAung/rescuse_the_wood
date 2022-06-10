using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egale_enemy_controller : MonoBehaviour
{
    public Transform[] points;
    public float movingspeed;
    public int currentpoint;
    public SpriteRenderer SR;
    public float attack_ds, chase_speed;
    private Vector3 attackterget;

    void Start()
    {
        for(int i=0;i<points.Length;i++)
        {
            points[i].parent = null;
        }
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, player_controller.instant.transform.position) > attack_ds)
        {
            attackterget = Vector3.zero;
            transform.position = Vector3.MoveTowards(transform.position, points[currentpoint].position, movingspeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, points[currentpoint].position) < 0.5f)
            {
                currentpoint++;
                if (currentpoint >= points.Length)
                {
                    currentpoint = 0;
                }
            }

            if (transform.position.x < points[currentpoint].position.x)
            {
                SR.flipX = true;
            }
            else if (transform.position.x > points[currentpoint].position.x)
            {
                SR.flipX = false;
            }
        }else
        {
            if(attackterget==Vector3.zero)
            {
                attackterget = player_controller.instant.transform.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, attackterget, chase_speed * Time.deltaTime);
            if (transform.position.x < attackterget.x)
            {
                SR.flipX = true;
            }
            else if (transform.position.x > attackterget.x)
            {
                SR.flipX = false;
            }
        }

       
    }
}
