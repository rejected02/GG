using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTrack : MonoBehaviour
{
    public Slider slider;
    float currentSliderValue;
    [SerializeField] float maxSize = 4.0f;
    [SerializeField] float minSize = 1.0f;

    void Update()
    {
        SliderInput();
    }
    public void SliderInput()
    {
        currentSliderValue =  slider.value;

        if ((currentSliderValue <= slider.maxValue && currentSliderValue >= slider.minValue))
        {
            Vector3 Scale = new Vector3(minSize, maxSize * currentSliderValue, minSize +(3.6f-maxSize * currentSliderValue));

            Vector3 nn = new Vector3(Scale.x, Mathf.Clamp(Scale.y, 0.6f, 4), Mathf.Clamp(Scale.z, 1.0f, 4.0f));
            transform.localScale = nn;

        }
        slider.value = Mathf.Clamp(slider.value, 0.1f, 1);
    }
   
}
