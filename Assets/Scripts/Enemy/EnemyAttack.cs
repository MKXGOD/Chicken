using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int _damage;
    private float _attackRate = 5;
    private float _nextAttack;

    public void SetDamageValue(int value)
    { 
        _damage = value;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Time.time > _nextAttack)
        {
            _nextAttack = Time.time + _attackRate;
            if (other.gameObject.TryGetComponent(out IDamageble iDamageble))
                iDamageble.Damage(_damage);   

        }
    }

}
