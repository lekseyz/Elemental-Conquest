using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInfo : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private Transform hero;
    [SerializeField] private float dist;

    void Update()
    {
        if (Vector2.Distance(transform.position, hero.position) < dist)
            image.SetActive(true);
        else
            image.SetActive(false);
    }

}