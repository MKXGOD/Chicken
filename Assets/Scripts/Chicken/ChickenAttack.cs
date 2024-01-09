using UnityEngine;
using UnityEngine.UI;

public class ChickenAttack:MonoBehaviour
{
    [SerializeField] private AudioSource _audioPunch;
    [SerializeField] private Button _buttonAttack;

    private LevelSystem _levelSystem;
    private ChickenStats _chickenPower;
    private ChickenAnimation _animations;

    private float _basePower = 1;
    private float _attackRate = 3;
    private float _nextAttack;

    public void InitAttackSystem(LevelSystem levelSystem, ChickenStats chikenPower, ChickenAnimation animations)
    { 
        _levelSystem = levelSystem;
        _chickenPower = chikenPower;
        _animations = animations;
    }
    private void Start()
    {
        _buttonAttack.onClick.AddListener(ClickButton);
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageble iDamageble))
        {
            iDamageble.OnDeath += OnEnemyDeath;
            _audioPunch.Play();
            iDamageble.Damage(_chickenPower.CalculatedDamage(_basePower));   
        }
    }
    private void OnEnemyDeath(int exp)
    {
        _levelSystem.AddExperience(exp);
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
