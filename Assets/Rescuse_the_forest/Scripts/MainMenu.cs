using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string start_scence,continue_scence;
    public GameObject continue_button;
    void Start()
    {
        if(PlayerPrefs.HasKey(start_scence+"_unlocked"))
        {
            continue_button.SetActive(true);
        }else
        {
            continue_button.SetActive(false);
        }
    }

    
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(start_scence);
        PlayerPrefs.DeleteAll();
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(continue_scence);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
