using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //dir = new Vector3(Mathf.Cos(transform.rotation.z), Mathf.Sin(transform.rotation.z), 0);
        transform.position += dir * speed * Time.deltaTime;  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            other.gameObject.GetComponent<Interactable>().applyFireBall();
        }

        if (other.gameObject.tag != "Player")
        {
            
            Destroy(gameObject);

        }
    }
}
