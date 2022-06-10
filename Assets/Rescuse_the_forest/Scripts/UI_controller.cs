using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_controller : MonoBehaviour
{
    public static UI_controller instant;
    public Sprite fullhealth, halfhealth,emptyhealth;
    public Image health1, health2, health3;
    public Text gentext;
    public Image FadeScreen;
    public GameObject Fade;
    public float fade_speed;
    public bool fade_to_black, fade_from_black;
    public GameObject level_complete_text;



    private void Start()
    {
        gentext.text = level_manager.instant.countgen.ToString();
    }
    private void Awake()
    {
        instant = this;
        
    }
    void Update()
    {
        if(fade_to_black)
        {
            Fade.SetActive(true);
            FadeScreen.color = new Color(FadeScreen.color.r, FadeScreen.color.g, FadeScreen.color.b, Mathf.MoveTowards(FadeScreen.color.a, 1f, fade_speed * Time.deltaTime));
            if(FadeScreen.color.a==1f)
            {
                fade_to_black = false;
                
                Fade.SetActive(false);
            }
          
        }
        if (fade_from_black)
        {
            Fade.SetActive(true);
            FadeScreen.color = new Color(FadeScreen.color.r, FadeScreen.color.g, FadeScreen.color.b, Mathf.MoveTowards(FadeScreen.color.a, 0f, fade_speed * Time.deltaTime));
            if (FadeScreen.color.a == 0f)
            {
                fade_from_black = false;
                Fade.SetActive(false);
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
    public void updateUI()
    {
        switch(player_health_control.instant.current_health)
        {
            case 6:
                health1.sprite = fullhealth;
                health2.sprite = fullhealth;
                health3.sprite = fullhealth;
                break;


            case 5:
                health1.sprite = fullhealth;
                health2.sprite = fullhealth;
                health3.sprite = halfhealth;
                break;

            case 4:
                health1.sprite = fullhealth;
                health2.sprite = fullhealth;
                health3.sprite = emptyhealth;
                break;

            case 3:
                health1.sprite = fullhealth;
                health2.sprite = halfhealth;
                health3.sprite = emptyhealth;
                break;

            case 2:
                health1.sprite = fullhealth;
                health2.sprite = emptyhealth;
                health3.sprite = emptyhealth;
                break;

            case 1:
                health1.sprite = halfhealth;
                health2.sprite = emptyhealth;
                health3.sprite = emptyhealth;
                break;

            case 0:
                health1.sprite = emptyhealth;
                health2.sprite = emptyhealth;
                health3.sprite = emptyhealth;
                break;

            

            default:
                health1.sprite = emptyhealth;
                health2.sprite = emptyhealth;
                health3.sprite = emptyhealth;
                break;



        }
        gentext.text = level_manager.instant.countgen.ToString();
    }
}
