using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]Transform objPosition;
    Vector3 offset;
    [SerializeField] float cameraSpeed;
    
    void Start()
    {
        offset = objPosition.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = objPosition.position - offset;

        transform.position = Vector3.Lerp(transform.position, target, cameraSpeed * Time.deltaTime);    
    }
}
