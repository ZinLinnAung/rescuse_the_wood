using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LS_UI_controller : MonoBehaviour
{
    public static LS_UI_controller instant;
    public Image FadeScreen;
    
    public float fade_speed;
    public bool fade_to_black, fade_from_black;
    public GameObject showInfoPannel;
    public Text levelName,GemFound,GemTerget,BestTime,BestTimeTerget;
    private void Awake()
    {
        instant = this;
    }
    void Start()
    {
        fadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (fade_to_black)
        {
           
            FadeScreen.color = new Color(FadeScreen.color.r, FadeScreen.color.g, FadeScreen.color.b, Mathf.MoveTowards(FadeScreen.color.a, 1f, fade_speed * Time.deltaTime));
            if (FadeScreen.color.a == 1f)
            {
                fade_to_black = false;

                
            }

        }
        if (fade_from_black)
        {
            
            FadeScreen.color = new Color(FadeScreen.color.r, FadeScreen.color.g, FadeScreen.color.b, Mathf.MoveTowards(FadeScreen.color.a, 0f, fade_speed * Time.deltaTime));
            if (FadeScreen.color.a == 0f)
            {
                fade_from_black = false;
                
            }
        }
    }
    public void fadeToBlack()
    {
        fade_to_black = true;
        fade_from_black = false;
    }

    public void fadeFromBlack()
    {
        fade_from_black = true;
        fade_to_black = false;
    }

    public void showInfo(MapPoint levelInfo)
    {
        levelName.text = levelInfo.levelName;
        GemFound.text ="Found: "+ levelInfo.Gemcollected;
        GemTerget.text = "In Level: " + levelInfo.TergetGem;
        BestTimeTerget.text = "Terget: " + levelInfo.TergetTime + "s";
        if (levelInfo.BestTime == 0)
        {
            BestTime.text = "Best: ___";
        } else
        {
            BestTime.text = "Best: " + levelInfo.BestTime.ToString("F1") + "s";
                
        }

        showInfoPannel.SetActive(true);
    }

    public void hideInfo()
    {
        showInfoPannel.SetActive(false);
    }
}
