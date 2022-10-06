using UnityEngine;

public class ChickenAttack : MonoBehaviour
{
    public ChickenAnimation Animation;
    public Chicken Chicken;

    public AudioSource Punch;

    private IDamagebleEnemy _iDamagebleEnemy;

    private float _attackRate = 3;
    private float _nextAttack;

    public void OnTriggerEnter (Collider other)
    {
        Attack();

        var target = other.gameObject;
        _iDamagebleEnemy = target.GetComponent<IDamagebleEnemy>();

        if(_iDamagebleEnemy != null && target != null)
           _iDamagebleEnemy.Damage(Chicken.Damage(), target);
    }
    public void ClickButton()
    {
        if (Time.time > _nextAttack)
        {
            _nextAttack = Time.time + _attackRate;
            Attack();
        }
        else Animation.TurnHead();
    }
    public void Attack()
    {
        Animation.AttackAnimation();
        Punch.Play();
    }
}
