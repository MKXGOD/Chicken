using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GroundEnemy _prefabEnemy;
    [SerializeField] private List<GroundEnemy> _currentEnemies = new List<GroundEnemy>();

    private Collider _levelCollider;
    private Vector3 _levelHalfSize;

    [SerializeField] private int _enemyAmount = 5;

    private void Awake()
    {
        _levelCollider = GetComponent<Collider>();
        _levelHalfSize = _levelCollider.bounds.min / 2;
        
    }
    private void Spawn(int enemyAmount)
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            GroundEnemy enemy = Instantiate(_prefabEnemy, _levelCollider.transform);
            enemy.transform.localPosition = new Vector3(Random.Range(_levelHalfSize.x + 0.2f, -_levelHalfSize.x - 0.2f), 0.4f, Random.Range(_levelHalfSize.z + 0.2f, -_levelHalfSize.z - 0.2f));
            enemy.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            _currentEnemies.Add(enemy);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_currentEnemies.Count >= _enemyAmount)
                return;
            int enemyAmount = _enemyAmount - _currentEnemies.Count;
            Spawn(enemyAmount);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var enemy in _currentEnemies)
            {
                if(enemy != null) Destroy(enemy.gameObject);
            }
            _currentEnemies.Clear(); 
        }
    }
}
