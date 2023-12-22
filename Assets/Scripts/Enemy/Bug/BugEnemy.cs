using UnityEngine;

public class BugEnemy : BaseEnemy
{
    [SerializeField] private HealthBar _healthBar;

    private void Start()
    {
        Level = 2;
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
