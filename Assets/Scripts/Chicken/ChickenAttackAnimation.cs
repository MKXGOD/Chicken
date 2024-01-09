using UnityEngine;
using UnityEngine.UI;

public class ChickenAttackAnimation
{
    private ChickenAnimation _animations;
    private ChickenStats _powerStats;
    private Button _buttonAttack;

    private float _attackDamage;
    private float _attackRate = 3;
    private float _nextAttack;

    public ChickenAttackAnimation(ChickenAnimation animations, ChickenStats powerStats, Button buttonAttack)
    {
        _animations = animations;
        _powerStats = powerStats;
        _buttonAttack = buttonAttack;

        _buttonAttack.onClick.AddListener(ClickButton);
    }
    public float AttackDamage()
    {
        _attackDamage = _powerStats.Value;

        return _attackDamage;
    }
    public void ClickButton()
    {
        if (Time.time > _nextAttack)
        {
            _nextAttack = Time.time + _attackRate;
            _animations.AttackAnimation();
        }
        else _animations.TurnHeadAnimation();
    }
}