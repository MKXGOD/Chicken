using UnityEngine;

public class WormsEnemy : BaseEnemy
{
    [SerializeField] private HealthBar _healthBar;
    private void Start()
    {
        Level = 1; 
        MaxHP = 100 + (100 * (Level / 10));
        CurrentHP = MaxHP;
        Exp = 10 + (10 * Level);
        _healthBar.HpBarMaxValue(MaxHP);
    }

    private void Update()
    {
        _healthBar.HpBarCurrentValue(CurrentHP);
    }
}
