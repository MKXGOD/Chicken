using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Slider LevelBar;
    public Text LevelTxt;
    public LevelChicken LevelChicken;

    private void Awake()
    {
        LevelChicken.OnLevelValueChangedEvent += OnLevelValueChanged;
        TextLevel();
        LevelBar.maxValue = 100;
        LevelBar.value = LevelChicken.LevelPoint;
    }

    private void OnLevelValueChanged(int newValue)
    {
        LevelBar.value = newValue;
        LevelBarCurrent();
        TextLevel();
    }
    public void LevelBarCurrent()
    {
        LevelBar.value = LevelChicken.LevelPoint;
    }

    public void TextLevel()
    {
        LevelTxt.text = "Level: " + LevelChicken.Level;
    }
}
