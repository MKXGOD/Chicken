using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chicken : MonoBehaviour, IDamageble
{
    private CharacterController _characterController;
    private Animator _animator;

    private ChickenAnimation _chikenAnimation;
    private ChickenAttack _chikenAttack;
    private ChickenMovement _chikenMovement;
    private ChickenHealth _chikenHealth;

    [SerializeField] private HealthBar _healthBar;

    [SerializeField] private Joystick _joystickMove;
    [SerializeField] private Button _buttonAttack;

    [SerializeField] private AudioSource _chikenStep;


    private List<ChickenStats> _chikenStats;
    [SerializeField] private List<UpgradeStats> _upgradeStats;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _chikenStats = new List<ChickenStats>()
        {
            new ChickenStats(ChickenStats.Stats.Power, "PowerAttack", 1, 5, 1),
            new ChickenStats(ChickenStats.Stats.Speed, "SpeedRun", 1, 1, 1),
            new ChickenStats(ChickenStats.Stats.HealthPoint, "Health", 10, 3, 1),
        };
        for (int i = 0; i < _upgradeStats.Count; i++)
            _upgradeStats[i].SetData(_chikenStats[i]);

        _chikenAnimation = new ChickenAnimation(_animator);
        _chikenAttack = new ChickenAttack(_chikenAnimation, _chikenStats[1], _buttonAttack);
        _chikenMovement = new ChickenMovement(_chikenStep, _joystickMove, _chikenStats[1]);
        _chikenHealth = new ChickenHealth(_chikenStats[2], _healthBar);
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        _characterController.Move(_chikenMovement.MoveVector() * Time.deltaTime);
        _chikenAnimation.RunAnimation(_chikenMovement.MoveVector());

        //Rotate chiken
        if (Vector3.Angle(Vector3.forward, _chikenMovement.MoveVector()) > 1f || Vector3.Angle(Vector3.forward, _chikenMovement.MoveVector()) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _chikenMovement.MoveVector(), _chikenMovement.MovementSpeed(), 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
    }
    public void Damage(float damage)
    {
       _chikenHealth.Damage(damage);
    }
}
