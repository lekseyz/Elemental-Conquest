using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = slider.maxValue;
    }

    public void UpdateSliderVal(float val, float maxVal)
    {
        slider.value = val / maxVal;
    }
}
