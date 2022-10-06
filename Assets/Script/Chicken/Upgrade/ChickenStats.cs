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

    public int Value => InitValue + (int)IncreasePerLevel * Mathf.Clamp(Level, 0, int.MaxValue);
    public float IncreasePerLevel { get; private set; }
    public int InitValue { get; private set; }
    public int Price { get; private set; }

    public int Level { get; private set; }

    public string NameStats { get; private set; }

    public ChickenStats(Stats type, string nameStats, int value, float increasePerLevel,int price)
    {
        Type = type;
        IncreasePerLevel = increasePerLevel;
        InitValue = value;
        Price = price;
        NameStats = nameStats;
    }

    public int CalculatedDamage(int Damage)
    {
        switch (Type)
        { 
            case Stats.Power:
                return Damage + Value;
            default:
                return Damage;
        }
    }
    public int CalculatedMoveSpeed(int Speed)
    {
        switch (Type)
        {
            case Stats.Speed:
                return Speed + Value;
            default:
                return Speed;
        }
    }
    public int CalculatedHealthPoint(int Health)
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
