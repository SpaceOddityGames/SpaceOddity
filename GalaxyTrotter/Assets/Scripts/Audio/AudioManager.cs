using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Pause();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }

    public void UpdateVolume(float v)
    {
        foreach(Sound s in sounds)
        {
            if (!s.music) {
                s.volume = v;
                s.source.volume = s.volume;
            }
        }
        PlayerPrefs.SetFloat("volume", v);
        PlayerPrefs.Save();
    }

    public void UpdateMusic(float v)
    {
        foreach (Sound s in sounds)
        {
            if (s.music)
            {
                s.volume = v;
                s.source.volume = s.volume;
            }
        }
        PlayerPrefs.SetFloat("music", v);
        PlayerPrefs.Save();
    }

    public void DecreaseMusic()
    {
        foreach (Sound s in sounds)
        {
            if (s.music)
            {
                s.source.volume = s.source.volume * 0.5f;
            }
        }
    }

    public void IncreaseMusic()
    {
        foreach (Sound s in sounds)
        {
            if (s.music)
            {
                s.source.volume = s.source.volume * 2f;
            }
        }
    }
}
