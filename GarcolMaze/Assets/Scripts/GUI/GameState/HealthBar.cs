using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image image;
    public void setHealth(int health)
    {
        if (slider != null)
        {
            slider.value = health;

            if (image != null && gradient != null)
            {
                image.color = gradient.Evaluate(slider.normalizedValue);
            }
        }
    }

    public void setMaxHealth(int health)
    {
        if (slider != null)
        {
            slider.maxValue = health;
            slider.value = health;

            if (image != null && gradient != null)
            {
                image.color = gradient.Evaluate(1f);
            }
        }
    }
}
