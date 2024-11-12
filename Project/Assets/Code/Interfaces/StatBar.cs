using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxValue(int maxValue)
    {
        slider.maxValue = maxValue;
    }
    public void SetValue(int value)
    {
        slider.value = value;
    }

    public float GetMaxValue()
    {
        return slider.maxValue;
    }

    public float GetValue()
    {
        return slider.value;
    }
}
