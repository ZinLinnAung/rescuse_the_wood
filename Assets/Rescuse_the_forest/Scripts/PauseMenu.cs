using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public bool ispause;
    public GameObject pauseScreen;
    public string main_menu, level_select;
    void Start()
    {
        
        pauseScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            unpause_pause();
        }
    }

    public void unpause_pause()
    {
        if(ispause)
        {
            ispause = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;

        }
        else
        {
            ispause = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Main_Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(main_menu);
    }
    public void Level_selected()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level_select);
    }
}
