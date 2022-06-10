using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_manager : MonoBehaviour
{

    public static Audio_manager instance;
    public AudioSource[] sources;
    public AudioSource bgm, end_music;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySFX(int sound_to_play)
    {
        sources[sound_to_play].Stop();
        sources[sound_to_play].pitch = Random.Range(0.9f, 1.1f);
        sources[sound_to_play].Play();
    }
    public void PlayLevelVistory()
    {
        bgm.Stop();
        end_music.Play();
    }
}
