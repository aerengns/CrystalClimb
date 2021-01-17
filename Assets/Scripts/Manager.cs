using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject pauseMenu;

    public TextMeshProUGUI text;
    public Slider mySlider;
    public Image img;
    public GameObject player;
    public Sprite on, off;

    private bool isMuted;

    private void Awake()
    {
        isMuted = false;
    }



    public void slide()
    {
        float value = mySlider.value;
        if (value > 0.5)
        {
            player.GetComponent<Grappling>().easy = false;
            PlayerPrefs.SetInt("easy", 0);
        }
        else
        {
            player.GetComponent<Grappling>().easy = true;
            PlayerPrefs.SetInt("easy", 1);
        }
    }

    public void showPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false) ;
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    public void updateScore(int score)
    {
        text.text = "Score: " + Convert.ToString(score);
    }

    public void Restarter()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MutePressed()
    {
        if(isMuted == true)
        {
            isMuted = false;
            AudioListener.pause = isMuted;
            img.sprite = on;
        }
        else
        {
            isMuted = true;
            AudioListener.pause = isMuted;
            img.sprite = off;
        }
        
    }
}
