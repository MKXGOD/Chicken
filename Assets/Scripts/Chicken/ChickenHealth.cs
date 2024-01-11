public class ChickenHealth
{
    private HealthBar _healthBar;

    private ChickenStats _healthStats;

    private float _maxHealth;
    private float _health;
    private float _baseHealth = 5;

    public float Health => _health;

    public ChickenHealth(ChickenStats maxHealthStats, HealthBar healthBar)
    {
        _healthStats = maxHealthStats;
        _healthBar = healthBar;

        InitHealthBar();
    }

    private void InitHealthBar()
    {
        UpgradeMaxHealth();
        _health = _maxHealth;
        _healthBar.HpBarCurrentValue(_health);
    }

    public void UpgradeMaxHealth()
    {
        _maxHealth = _healthStats.CalculatedHealthPoint(_baseHealth);
        _healthBar.HpBarMaxValue(_maxHealth);
    }

    public void Damage(float amount)
    {
        _health -= amount;
        _healthBar.HpBarCurrentValue(_health);
    }

    public void Heal(float amount)
    { 
        _health += amount;
        _healthBar.HpBarCurrentValue(_health);
    }
}