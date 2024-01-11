public class LevelSystem
{
    public delegate void ExperienceHandler();
    public event ExperienceHandler OnExperienceChanged;
    public event ExperienceHandler OnLevelChanged;

    private float _experience;
    private float _experienceToNextLevel;
    private int _level;

    public LevelSystem() 
    {
        _experience = 0;
        _level = 0;
        _experienceToNextLevel = 100;
    }

    public void AddExperience(int amount)
    { 
        _experience += amount;
        while (_experience >= _experienceToNextLevel)
        {
            _experience -= _experienceToNextLevel;
            _level++;
            OnLevelChanged?.Invoke();
        }
        OnExperienceChanged?.Invoke();
    }

    public int GetLevelNumber()
    {
        return _level;
    }
    public float GetExperienceNormalized()
    { 
        return _experience / _experienceToNextLevel;
    }

}
