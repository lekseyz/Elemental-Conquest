using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource AudioSrc;
    private float musicVolume = 1f;


    // Start is called before the first frame update
    void Start()
    {
        AudioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSrc.volume = musicVolume;
        
    }

    public void SetVolume(float volume)
    { musicVolume = volume; }
}
