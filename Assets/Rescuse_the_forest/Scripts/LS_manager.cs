using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LS_manager : MonoBehaviour
{
    public LS_player_controller theplayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }
    public IEnumerator LoadLevelCo()
    {
        LS_UI_controller.instant.fadeToBlack();
        yield return new WaitForSeconds((1/LS_UI_controller.instant.fade_speed)+.25f);
        SceneManager.LoadScene(theplayer.currentpoint.leveltoload);

    }
}
