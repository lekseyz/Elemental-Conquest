using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate : MonoBehaviour
{
    [SerializeField] private GameObject torch;
    [SerializeField] private GameObject bossText;
    [SerializeField] private GameObject bossBar;
    [SerializeField] private WallMove movement;
    [SerializeField] private GameObject boss;
    [SerializeField] private MusicManager musicManager; // Добавляем ссылку на MusicManager

    private bool triggered = false;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !triggered)
        {
            triggered = true;
            musicManager.SwitchToBossMusic();
            movement.closeWall();
            boss.SetActive(true);
            bossText.SetActive(true);
            bossBar.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
