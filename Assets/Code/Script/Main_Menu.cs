using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mein_Menu : MonoBehaviour 
{

    public GameObject settingsPanel; //тут будет описана панель настроек


    public void PlayGame() //играть))))
    {
        //SeceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Application.LoadLevel("ZeroVerScene");
    }

    public void ExitGame() //выход из игры
    {
        Application.Quit();
    }

    public void SettingsPanel() //открывает панель настроек
    {
        settingsPanel.SetActive(true);
    }

    public void ExitSettings()   //Выходит из панели настроек
    {
        settingsPanel.SetActive(false);
    }
}
