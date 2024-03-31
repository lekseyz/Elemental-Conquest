using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
        GameObject MainHero = GameObject.Find("MainHero");
        MainHero.GetComponent<Walk>().enabled = true;
        MainHero.GetComponent<Attack>().enabled = true;
        GameObject HideShow = GameObject.Find("BackGround Trigger");
        HideShow.GetComponent<HideShowMenu>().enabled = true;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
        GameObject MainHero = GameObject.Find("MainHero");
        MainHero.GetComponent<Walk>().enabled = false;
        MainHero.GetComponent<Attack>().enabled = false;
        GameObject HideShow = GameObject.Find("BackGround Trigger");
        HideShow.GetComponent<HideShowMenu>().enabled = false;

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
}