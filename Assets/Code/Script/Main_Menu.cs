using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mein_Menu : MonoBehaviour 
{

    public GameObject settingsPanel; //��� ����� ������� ������ ��������


    public void PlayGame() //������))))
    {
        //SeceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Application.LoadLevel("ZeroVerScene");
    }

    public void ExitGame() //����� �� ����
    {
        Application.Quit();
    }

    public void SettingsPanel() //��������� ������ ��������
    {
        settingsPanel.SetActive(true);
    }

    public void ExitSettings()   //������� �� ������ ��������
    {
        settingsPanel.SetActive(false);
    }
}
