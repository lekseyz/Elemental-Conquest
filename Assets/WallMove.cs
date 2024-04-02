using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    Vector3 defaultPos;
    Vector3 openPos;
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        defaultPos = gameObject.transform.position;
        openPos = gameObject.transform.position + Vector3.up * 7;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, isOpen ? openPos : defaultPos, Time.deltaTime);
    }

    public void openWall()
    {
        isOpen = true;
    }

    public void closeWall()
    {
        isOpen = false;
    }
}
