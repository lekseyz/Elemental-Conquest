using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private Transform table;
    //[SerializeField] private Transform table;
    [SerializeField] private float dist;

    void Update()
    {
        if (Vector2.Distance(transform.position, table.position) < dist)
            image.SetActive(true);
        else
            image.SetActive(false);
    }

}
