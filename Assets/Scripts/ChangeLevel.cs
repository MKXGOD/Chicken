using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] EnemiesSpawners;

    private EnemyController _bugsEnemy;
    private EnemyController _wormsEnemy;

    private void Awake()
    {
        _wormsEnemy = EnemiesSpawners[0].GetComponent<EnemyController>();
        _bugsEnemy = EnemiesSpawners[1].GetComponent<EnemyController>();
        
        EnemiesSpawners[1].SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        Change();
    }

    private void Change()
    {
        if (EnemiesSpawners[0] != null)
        {
            EnemiesSpawners[0].SetActive(false);
            _wormsEnemy.DestroyEnemy();
            EnemiesSpawners[1].SetActive(true);
        }
        else
        {
            EnemiesSpawners[1].SetActive(false);
            _bugsEnemy.DestroyEnemy();
            EnemiesSpawners[0].SetActive(true);
        }
    }
}
