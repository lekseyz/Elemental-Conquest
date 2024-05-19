using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public static bool respawnInScene1 = false; // Переменная для определения, в какой сцене респаунить героя

    public void ExitGame() // Выход из игры
    {
        Application.Quit();
    }

    public void RespawnGame() // Респавн
    {
        if (respawnInScene1) // Проверяем, в какой сцене респаунить героя
        {
            SceneManager.LoadScene("Scene1");
        }
        else
        {
            SceneManager.LoadScene("Dungeon");
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
