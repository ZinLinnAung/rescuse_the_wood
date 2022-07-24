using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LS_player_controller : MonoBehaviour
{
    public MapPoint currentpoint;
    public float PlayerPositionX;
    public float PlayerPositionY;
    public float movespeed = 10f;
    public bool levelLoading = false;
    public LS_manager themanager;
    public bool next = false;
    public bool select = false;
    private void Awake()
    {
        GetPlayerPosition();

    }
    

    
    void LateUpdate()
    {
        if(next==true)
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
                if (currentpoint.islevel && currentpoint.leveltoload != "" && !currentpoint.islock)
                {
                    LS_UI_controller.instant.showInfo(currentpoint);
                    if (Input.GetButtonDown("Jump"))
                    {
                        Audio_manager.instance.PlaySFX(4);
                        levelLoading = true;
                        SetPlayerPosition();
                        themanager.LoadLevel();
                    }
                }else if (currentpoint.islock)
                {
                    LS_UI_controller.instant.showError(currentpoint);
                }
            }
           
            
        }
        Debug.Log(PlayerPositionX + ":" + PlayerPositionY);
    }
    void SetnextPoint(MapPoint nextpoint)
    {
        currentpoint = nextpoint;
        LS_UI_controller.instant.hideInfo();
        Audio_manager.instance.PlaySFX(5);
    }

    void SetPlayerPosition()
    {
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_PlayerPositionX"))
        {
           
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_PlayerPositionX",currentpoint.transform.position.x);
               

        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_PlayerPositionX",currentpoint.transform.position.x);
        }

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_PlayerPositionY"))
        {

            
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_PlayerPositionY",currentpoint. transform.position.y);

        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_PlayerPositionY", currentpoint.transform.position.y);
        }
        
    }

    void GetPlayerPosition()
    {
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_PlayerPositionX"))
        {
           PlayerPositionX = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_PlayerPositionX");
            
            
           
        }
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_PlayerPositionX"))
        {
            PlayerPositionY = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_PlayerPositionY");



        }
        transform.position = new Vector3(PlayerPositionX, PlayerPositionY, transform.position.z);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!select)
        {

            SetnextPoint(collision.gameObject.GetComponent<MapPoint>());
            next = true;
            Debug.Log("yay");
            select = true;
        }
        
    }

}
