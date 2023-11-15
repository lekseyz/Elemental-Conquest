using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Patroler : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField] public float findDistance;
    public List<Transform> points = new List<Transform>();

    Transform player;
    private int currentPointIndex;
    bool chill = false;
    bool angry = false;
    bool goback = false;
    void Start()
    {
        currentPointIndex = Random.Range(0, points.Count);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //Debug.Log(currentPointIndex + "    " + points[currentPointIndex].position);
        if (Vector2.Distance(transform.position, points[currentPointIndex].position) < 1 && angry == false)
        {
            currentPointIndex = Random.Range(0, points.Count);
            chill = true;
        
        }

        if (Vector2.Distance(transform.position, player.position) < findDistance)
        {
            angry = true;
            chill = false;
            goback = false;
        }

        if (Vector2.Distance(transform.position, player.position) > findDistance)
        {
            goback = true;
            angry = false;
        }

        if (chill == true)
        {
            Chill();
        }

        else
        if (angry == true)
        {
            Angry();
        }
        
        else
        if (goback == true)
        {
            goBack();
        }
    }

    void Chill()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 4;
    }

    void goBack()
    {
        speed = 1;
        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
    }
}
