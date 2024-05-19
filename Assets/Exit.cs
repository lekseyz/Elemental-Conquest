using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public static bool respawnInScene1 = false; // ���������� ��� �����������, � ����� ����� ���������� �����

    public void ExitGame() // ����� �� ����
    {
        Application.Quit();
    }

    public void RespawnGame() // �������
    {
        if (respawnInScene1) // ���������, � ����� ����� ���������� �����
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
