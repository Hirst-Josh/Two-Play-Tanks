using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;


public class SoundAssets : MonoBehaviour
{
    private bool FirstSourceplaying;
    private static SoundAssets instance;
    public static SoundAssets sound
    {
        get
        { 
            if(instance == null)
        
            instance = FindObjectOfType<SoundAssets>();
            if(instance == null)
            {
                instance = new GameObject("spawned soundassets", typeof(SoundAssets)).GetComponent<SoundAssets>();
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private AudioSource musicsource1;
    private AudioSource musicsource2;
    private AudioSource sfxsource;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        musicsource1 = gameObject.AddComponent<AudioSource>();
        musicsource2 = gameObject.AddComponent <AudioSource>();
        sfxsource = gameObject.AddComponent<AudioSource>();

        musicsource1.loop = true;
        musicsource2.loop = true;
    }

    public void playMusic(AudioClip musicclip)
    {
        AudioSource active = (FirstSourceplaying) ? musicsource1 : musicsource2;

        musicsource1.clip = musicclip;
        musicsource1.volume = 1;
        musicsource1.Play();
    }

    public void playmusicfade(AudioClip AudioClip, float transitiontime = 1.0f)
    {
        AudioSource active = (FirstSourceplaying) ? musicsource1 : musicsource2;
        StartCoroutine(UpdatemusicFade(active, AudioClip, transitiontime));
    }

    public void playmusiccrossfade(AudioClip AudioClip, float transitiontime = 1.0f)
    {
        AudioSource active = (FirstSourceplaying) ? musicsource1 : musicsource2;
        AudioSource newsource = (FirstSourceplaying) ? musicsource2 : musicsource1;

        FirstSourceplaying = !FirstSourceplaying;

        newsource.clip = AudioClip;
        newsource.Play();
        StartCoroutine(UpdatemusicrossFade(active, newsource, transitiontime));
    }


    private IEnumerator UpdatemusicFade(AudioSource activesource, AudioClip newclip, float transition)
    {
        if (!activesource.isPlaying)
        {
            activesource.Play();
            float t = 0.0f;
            //fade in
            for(t = 0; t < transition; t += Time.deltaTime)
            {
                activesource.volume = (1 - (t / transition));
                yield return null;
            }
            activesource.Stop();
            activesource.clip = newclip;
            activesource.Play();
            //fade out
            for (t = 0; t < transition; t += Time.deltaTime)
            {
                activesource.volume = (t / transition) ;
                yield return null;
            }
        }

    }


    private IEnumerator UpdatemusicrossFade(AudioSource original, AudioSource newclip, float transition)
    {
       
            float t = 0.0f;
            //fade in
            for (t = 0; t < transition; t += Time.deltaTime)
            {
                original.volume = (1 - (t / transition));
                newclip.volume = (t / transition);
                yield return null;
            }
            original.Stop();
            

    }

    public void PlaySfx(AudioClip clip)
    {
        sfxsource.PlayOneShot(clip);
    }


    public void setmusicvoulme(float volume)
    {
        musicsource1.volume = volume;
        musicsource2.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxsource.volume = volume;
    }
}
