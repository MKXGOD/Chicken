using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemy : MonoBehaviour, IDamageble
{
    [Header("UI")]
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private TextMeshProUGUI _levelText;

    private NavMeshAgent _agent;
    private EnemyAI _enemyAI;
    private EnemyAttack _enemyAttack;
    private HitMarker _hitMarker;

    [Header("Enemy stats")]
    [SerializeField] private EnemyAI.Type _enemyType;
    [Space(10)]
    [SerializeField] private int _level;
    [SerializeField] private int _maxHp;
    [SerializeField] private int _exp;
    [SerializeField] private int _damageValue;
    [Header("AI parameters")]
    [SerializeField] private LayerMask _playerLayer;
    [Space(10)]
    [SerializeField] private float _speed;
    [SerializeField] private float _angularSpeed;
    [SerializeField] private float _viewRadius;
    private float _currentHp;

    public event IDamageble.DeathHandler OnDeath;

    private void Awake()
    {
        _hitMarker = GetComponent<HitMarker>();
        _agent = GetComponent<NavMeshAgent>();
        _enemyAI = new EnemyAI(_agent, _playerLayer, _enemyType ,_speed, _angularSpeed, _viewRadius);

        if (_enemyType == EnemyAI.Type._isAggressive)
        {
            _enemyAttack = gameObject.AddComponent<EnemyAttack>();
            _enemyAttack.SetDamageValue(_damageValue);
        }

    }
    private void Start()
    {
        _healthBar.HpBarMaxValue(_maxHp);
        _currentHp = _maxHp;
        _levelText.text = "Level: " + _level.ToString();
    }
    private void Update()
    {
        _enemyAI.View(transform);
    }
    public void Damage(float damage)
    {
        _currentHp -= damage;
        _hitMarker.HitMark();
        _healthBar.HpBarCurrentValue(_currentHp);
        if (_currentHp <= 0)
        {
            OnDeath?.Invoke(_exp);
            EffectController.Instance.SetClickEffect(_exp);
            Destroy(gameObject);
        }
    }

}
