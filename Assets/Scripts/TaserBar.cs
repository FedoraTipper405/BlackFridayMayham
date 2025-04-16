using UnityEngine;
using UnityEngine.UI;

public class TaserBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxTaserAmount(float taserAmount)
    {
        slider.maxValue = taserAmount;
        slider.value = taserAmount;
    }

    public void SetTaserAmount(float taserAmount)
    {
        slider.value = taserAmount;
    }
}
