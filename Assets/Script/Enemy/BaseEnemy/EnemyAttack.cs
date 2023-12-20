using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int _damage = 10;
    private float _attackRate = 5;
    private float _nextAttack;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Time.time > _nextAttack)
        {
            _nextAttack = Time.time + _attackRate;
            if (other.gameObject.TryGetComponent(out IDamageble iDamageble))
                iDamageble.Damage(_damage);   

        }
    }

}
