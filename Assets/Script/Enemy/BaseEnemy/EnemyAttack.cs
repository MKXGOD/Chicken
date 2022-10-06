using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int _damage = 10;
    private float _attackRate = 5;
    private float _nextAttack;
    private Chicken _chicken;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Time.time > _nextAttack)
        {
            var target = other.gameObject;
            _chicken = target.GetComponent<Chicken>();
            _nextAttack = Time.time + _attackRate;
            Attack();

        }
    }
    private void Attack()
    {
        _chicken.TakeDamage(_damage);
    }

}
