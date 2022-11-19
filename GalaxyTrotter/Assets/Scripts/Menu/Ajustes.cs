using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ajustes : MonoBehaviour
{
    [SerializeField] Slider volume;
    [SerializeField] Slider music;
    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("volume");
        music.value = PlayerPrefs.GetFloat("music");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
        }
    }
    public void SetVolume()
    {
        FindObjectOfType<AudioManager>().UpdateVolume(volume.value);
    }

    public void SetMusic()
    {
        FindObjectOfType<AudioManager>().UpdateMusic(music.value);
    }

    public void GoBack()
    {
        this.gameObject.SetActive(false);
    }
}
