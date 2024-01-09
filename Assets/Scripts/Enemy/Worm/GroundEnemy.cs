using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemy : MonoBehaviour, IDamageble
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private TextMeshProUGUI _levelText;

    private NavMeshAgent _agent;

    private EnemyAI _enemyAI;

    [SerializeField] private int _level;
    [SerializeField] private int _maxHp;
    [SerializeField] private int _exp;

    [SerializeField] private float _speed;
    [SerializeField] private float _angularSpeed;
    [SerializeField] private float _viewRadius;
    private float _currentHp;

    public event IDamageble.DeathHandler OnDeath;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemyAI = new EnemyAI(_agent, _playerLayer, EnemyAI.Type._isPeaceful ,_speed, _angularSpeed, _viewRadius);
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
        _healthBar.HpBarCurrentValue(_currentHp);
        if (_currentHp <= 0)
        {
            OnDeath?.Invoke(_exp);
            EffectController.Instance.SetClickEffect(_exp);
            Destroy(gameObject);
        }
    }

}
