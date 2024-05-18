using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDungeon : MonoBehaviour
{
    public IsPressed button;
    public Spike spike;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            button.gameObject.SetActive(false);
            spike.isActive = true;
            boss.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
