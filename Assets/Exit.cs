using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void ExitGame() //����� �� ����
    {
        Application.Quit();
    }

    public void RespawnGame() //�������
    {
        SceneManager.LoadScene("Scene1"); //SceneManager.GetActiveScene().buildIndex - ��������� �����(��������� ���� ����, � �� ����). �� �������� ��� ����� ���, ���� ����� ��������� �����
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
