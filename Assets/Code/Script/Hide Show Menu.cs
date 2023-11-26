using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowMenu : MonoBehaviour
{
    public GameObject BackGround;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            BackGround.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            BackGround.SetActive(false);
        }
    }
}