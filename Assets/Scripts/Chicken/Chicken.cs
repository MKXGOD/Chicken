using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour, IDamageble
{
    private CharacterController _characterController;
    private Animator _animator;
    private LevelSystem _levelSystem;
    private HitMarker _hitMarker;
    #region "Chicken class"
    private ChickenAnimation _chickenAnimation;
    private ChickenMovement _chickenMovement;
    private ChickenHealth _chickenHealth;
    
    [Header("Chicken class")]
    [SerializeField] private ChickenAttack _chickenAttack;
    #endregion
    #region"UI"
    [Header("UI components")]
    [SerializeField] private LevelWindow _levelWindow;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Joystick _joystickMove;
    #endregion
    [Header("Audio")]
    [SerializeField] private AudioSource _chickenStep;

    private List<ChickenStats> _chickenStats;
    [Header("Stats")]
    [SerializeField] private List<UpgradeStats> _upgradeStats;


    public event IDamageble.DeathHandler OnDeath;

    private void Awake()
    {
        _hitMarker = GetComponent<HitMarker>();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _chickenStats = new List<ChickenStats>()
        {
            new ChickenStats(ChickenStats.Stats.Power, "PowerAttack", 1, 2),
            new ChickenStats(ChickenStats.Stats.Speed, "SpeedRun", 0.6f, Mathf.Clamp(0.2f, 0, 2)),
            new ChickenStats(ChickenStats.Stats.HealthPoint, "Health", 5, Mathf.Clamp(2f, 0, 20)),
        };
        UpdateUIData();
        InitChickenComponent();
        InitLevelSystem();
    }

    private void InitChickenComponent()
    {
        _chickenAnimation = new ChickenAnimation(_animator);
        _chickenMovement = new ChickenMovement(_chickenStep, _joystickMove, _chickenStats[1]);
        _chickenHealth = new ChickenHealth(_chickenStats[2], _healthBar);
    }

    private void InitLevelSystem()
    {
        _levelSystem = new LevelSystem();
        _levelWindow.SetLevelSystem(_levelSystem);

        _chickenAttack.InitAttackSystem(_levelSystem, _chickenStats[0], _chickenAnimation);

        _levelSystem.OnLevelChanged += LevelUpStats;
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        _characterController.Move(_chickenMovement.MoveVector() * Time.deltaTime);
        _chickenAnimation.RunAnimation(_chickenMovement.MoveVector());

        //Rotate chiken
        if (Vector3.Angle(Vector3.forward, _chickenMovement.MoveVector()) > 1f || Vector3.Angle(Vector3.forward, _chickenMovement.MoveVector()) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _chickenMovement.MoveVector(), _chickenMovement.Speed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
    }
    public void Damage(float damage)
    {
       _chickenHealth.Damage(damage);
        _hitMarker.HitMark();
    }
    private void LevelUpStats()
    {
        foreach(var stat in _chickenStats)
            stat.LevelUp();

        _chickenHealth.UpgradeMaxHealth();
        UpdateUIData();
    }
    private void UpdateUIData()
    {
        for (int i = 0; i < _upgradeStats.Count; i++)
            _upgradeStats[i].SetData(_chickenStats[i]);
    }
}
