using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private AudioSource _levelUpAudio;

    private LevelSystem _levelSystem;

    private void SetBarSize(float normalizeValue)
    { 
        _bar.fillAmount = normalizeValue;
    }
    private void SetLevelNumber(int levelNumber)
    { 
        _levelText.text = "Level: " + levelNumber;
    }
    public void SetLevelSystem(LevelSystem levelSystem)
    { 
        _levelSystem = levelSystem;

        SetBarSize(_levelSystem.GetExperienceNormalized());
        SetLevelNumber(_levelSystem.GetLevelNumber());

        _levelSystem.OnExperienceChanged += OnExperienceChanged;
        _levelSystem.OnLevelChanged += OnLevelChanged;
    }
    private void OnExperienceChanged()
    {
        SetBarSize(_levelSystem.GetExperienceNormalized());
    }
    private void OnLevelChanged()
    {
        SetLevelNumber(_levelSystem.GetLevelNumber());
        _levelUpAudio.Play();
    }
}

