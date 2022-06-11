using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static level_manager instant;
    public float waitforsecond;
    [HideInInspector]
    public int countgen;
    public float timeInLevel;
    public string level_to_load;
    
    private void Awake()
    {
        instant = this;
    }
    void Start()
    {
        timeInLevel = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.instance.ispause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false ;
        }
        timeInLevel += Time.deltaTime;
    }
    public void RespawnPlayer()
    {
        StartCoroutine(respawnco());
    }

    public IEnumerator respawnco()
    {
        Audio_manager.instance.PlaySFX(8);
        player_controller.instant.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitforsecond-(1f/ UI_controller.instant.fade_speed));
        UI_controller.instant.fadeToBlack();
        yield return new WaitForSeconds((1f / UI_controller.instant.fade_speed) + 0.2f);
        UI_controller.instant.fadeFromBlack();
        player_controller.instant.gameObject.SetActive(true);
        player_controller.instant.transform.position = checkpoint_controller.instant.checkpointPosition;
        player_health_control.instant.current_health = player_health_control.instant.max_health;
        UI_controller.instant.updateUI();
    }

    public void ExitLevel()
    {
        StartCoroutine(ExitLevelCo());
    }
        
    public IEnumerator ExitLevelCo()
    {
        Audio_manager.instance.PlayLevelVistory();
        yield return new WaitForSeconds(0.3f);
        player_controller.instant.stop_input = true;
        camera_controll.instant.stopfollow = true;
        UI_controller.instant.level_complete_text.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UI_controller.instant.fadeToBlack();
        yield return new WaitForSeconds((1f / UI_controller.instant.fade_speed) + .25f);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked",1);
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name+"_gems"))
        {
            if(countgen>PlayerPrefs.GetInt(SceneManager.GetActiveScene().name+"_gems"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", countgen);
            }
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", countgen);
        }
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if(timeInLevel<PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }
        
        SceneManager.LoadScene(level_to_load);

    }
}
