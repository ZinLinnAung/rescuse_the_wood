using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapPoint : MonoBehaviour
{

    public MapPoint up, down, left, right;
    public bool islevel,islock;
    public string leveltoload,leveltocheck,levelName;
    public int Gemcollected, TergetGem;
    public float BestTime, TergetTime;
    public int currentpointnumber;
   
    void Start()
    {
        
        if (islevel && leveltoload != null)
        {
            if(PlayerPrefs.HasKey(leveltoload+"_gems"))
            {
                Gemcollected = PlayerPrefs.GetInt(leveltoload + "_gems");
            }
            if(PlayerPrefs.HasKey(leveltoload+"_time"))
            {
                BestTime = PlayerPrefs.GetFloat(leveltoload + "_time");
            }
            islock = true;
            if (leveltocheck != null)
            {
                
                if (PlayerPrefs.HasKey(leveltocheck + "_unlocked"))
                {
                    
                    if (PlayerPrefs.GetInt(leveltocheck + "_unlocked") == 1)
                    {
                       
                        islock = false;
                    }
                    else
                    {
                        
                        islock = true;
                    }
                }
                
            }
            if(leveltoload==leveltocheck)
            {
                islock = false;
            }
        }
    }

}

    
   
