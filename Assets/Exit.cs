using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitGame() //����� �� ����
    {
        Application.Quit();
    }
    public void RespawnGame()//�������
    {
        SceneManager.LoadScene("menu");
    }
}
