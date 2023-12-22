using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    public void HpBarMaxValue(float Health)
    {
        _slider.maxValue = Health;
        _slider.value = Health;
    }
    public void HpBarCurrentValue(float Health)
    {
        _slider.value = Health;
    }
}
