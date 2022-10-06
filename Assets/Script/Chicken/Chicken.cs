using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public HealthBar HealthBar; 

    private List<ChickenStats> _chickenStats;
    [SerializeField]private List<UpgradeStats> _upgradeStats;
    
    [Header ("Chicken Stats")]
    private int _healthMax;
    private int _healthCurrent;
    private int _damage;
    private int _speed;

    public void Start()
    {
        _chickenStats = new List<ChickenStats>()
        {
            new ChickenStats(ChickenStats.Stats.Power, "PowerAttack", 0, 5, 1),
            new ChickenStats(ChickenStats.Stats.Speed, "SpeedRun", 0, 1, 1),
            new ChickenStats(ChickenStats.Stats.HealthPoint, "Health", 0, 10, 1),
        };
        for (int i = 0; i < _upgradeStats.Count; i++)
            _upgradeStats[i].SetData(_chickenStats[i]);

        _healthMax = 100;
        _healthCurrent = _healthMax;
        HealthBar.HpBarMaxValue(_healthMax);

    }

    public int Damage()
    {
        _damage = 10;
        _damage = _chickenStats[0].CalculatedDamage(_damage);
        return _damage;
    }
    public float Speed()
    {
        _speed = 1;
        _speed = _chickenStats[1].CalculatedMoveSpeed(_speed);
        return _speed;
    }
    public int HealthPoint()
    {
        _healthMax = _chickenStats[2].CalculatedHealthPoint(_healthMax);
        return _healthMax;
    }
    public void TakeDamage(int Damage)
    {
        _healthCurrent -= Damage;
        HealthBar.HpBarCurrentValue(_healthCurrent);
    }
}
