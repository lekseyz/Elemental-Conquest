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

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            movement.closeWall();
            //torch.SetActive(false);
            boss.SetActive(true);
            bossText.SetActive(true);
            bossBar.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
