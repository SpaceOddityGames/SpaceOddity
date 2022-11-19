﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject iconoAjustes;
    [SerializeField] Slider volume;
    [SerializeField] Slider music;
    private bool isPaused = false;
    void Start()
    {
        pauseMenu.SetActive(false);
        volume.value = PlayerPrefs.GetFloat("volume");
        music.value = PlayerPrefs.GetFloat("music");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        iconoAjustes.SetActive(false);
        FindObjectOfType<AudioManager>().Pause("texto");
        FindObjectOfType<DialogController>().soundPlaying = false;
        FindObjectOfType<KitchenController>().disableAll();
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        iconoAjustes.SetActive(true);
        FindObjectOfType<KitchenController>().enableAll();
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void mainMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void SetVolume()
    {
        FindObjectOfType<AudioManager>().UpdateVolume(volume.value);
    }

    public void SetMusic()
    {
        FindObjectOfType<AudioManager>().UpdateMusic(music.value);
    }

    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("botonMenu");
    }
}
