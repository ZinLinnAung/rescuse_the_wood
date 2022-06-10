using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS_player_controller : MonoBehaviour
{
    public MapPoint currentpoint;
    public float movespeed = 10f;
    public bool levelLoading = false;
    public LS_manager themanager;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentpoint.transform.position, movespeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentpoint.transform.position) < .01f && !levelLoading)
        {
            if (Input.GetAxisRaw("Horizontal") > .5f)
            {
                if (currentpoint.right != null)
                {

                    SetnextPoint(currentpoint.right);
                }
            }
            if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                if (currentpoint.left != null)
                {

                    SetnextPoint(currentpoint.left);
                }
            }
            if (Input.GetAxisRaw("Vertical") > .5f)
            {
                if (currentpoint.up != null)
                {

                    SetnextPoint(currentpoint.up);
                }
            }
            if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                if (currentpoint.down != null)
                {

                    SetnextPoint(currentpoint.down);
                }
            }
            if(currentpoint.islevel && currentpoint.leveltoload!=""&& !currentpoint.islock)
            {
                LS_UI_controller.instant.showInfo(currentpoint);
                if (Input.GetButtonDown("Jump"))
                {
                    Audio_manager.instance.PlaySFX(4);
                    levelLoading = true;
                    themanager.LoadLevel();
                }
            }
        }
    }
    void SetnextPoint(MapPoint nextpoint)
    {
        currentpoint = nextpoint;
        LS_UI_controller.instant.hideInfo();
        Audio_manager.instance.PlaySFX(5);
    }
}
