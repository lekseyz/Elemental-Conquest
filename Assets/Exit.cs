using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void ExitGame() //выход из игры
    {
        Application.Quit();
    }

    public void RespawnGame() //респавн
    {
        SceneManager.LoadScene("Scene1"); //SceneManager.GetActiveScene().buildIndex - последняя сцена(загружает саму меню, а не игру). Не придумал как через это, если будет несколько миров
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
