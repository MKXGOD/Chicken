using System;
using UnityEngine;

public class ChickenBeak:MonoBehaviour
{
    private LevelSystem _levelSystem;
    [SerializeField] private LevelWindow _levelWindow;
    [SerializeField] private AudioSource _audioPunch;


    private void Awake()
    {
        _levelSystem = new LevelSystem();
        _levelWindow.SetLevelSystem(_levelSystem);
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageble iDamageble))
        {
            iDamageble.OnDeath += OnEnemyDeath;
            _audioPunch.Play();
            iDamageble.Damage(50);   
        }
    }

    private void OnEnemyDeath(int exp)
    {
        _levelSystem.AddExperience(exp);
    }
}
