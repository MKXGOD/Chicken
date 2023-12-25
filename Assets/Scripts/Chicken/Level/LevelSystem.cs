public class LevelSystem
{
    public delegate void ExperienceHandler();
    public event ExperienceHandler OnExperienceChanged;
    public event ExperienceHandler OnLevelChanged;

    private int _experience;
    private int _experienceToNextLevel;
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
        if (_experience >= _experienceToNextLevel)
        {
            _level++;
            _experience -= _experienceToNextLevel;
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
        return (float)_experience / _experienceToNextLevel;
    }

}
