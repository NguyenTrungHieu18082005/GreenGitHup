using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderExample : MonoBehaviour
{
    public Slider mySlider;
    public void OnSliderValueChange(float value){
        Debug.Log("Slider ValueL "+value);

    }
}
