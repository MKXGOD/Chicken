using UnityEngine;

public class ChickenStats
{
    public enum Stats
    { 
        Power,
        Speed,
        HealthPoint
    }
    public Stats Type { get; private set; }

    public float Value => InitValue + IncreasePerLevel * Mathf.Clamp(Level, 0, int.MaxValue);
    public float IncreasePerLevel { get; private set; }
    public float InitValue { get; private set; }

    public int Level { get; private set; }

    public string NameStats { get; private set; }

    public ChickenStats(Stats type, string nameStats, float value, float increasePerLevel)
    {
        Type = type;
        IncreasePerLevel = increasePerLevel;
        InitValue = value;
        NameStats = nameStats;
    }

    public float CalculatedDamage(float Damage)
    {
        switch (Type)
        { 
            case Stats.Power:
                return Damage + Value;
            default:
                return Damage;
        }
    }
    public float CalculatedHealthPoint(float Health)
    {
        switch (Type)
        {
            case Stats.HealthPoint:
                return Health + Value;
            default:
                return Health;
        }
    }

    public void LevelUp()
    {
        Level++;
    }
}
