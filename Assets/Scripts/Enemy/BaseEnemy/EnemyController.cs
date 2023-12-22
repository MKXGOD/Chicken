using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public GameObject Enemy;
    public List<GameObject> CurrentEnemy = new List<GameObject>();

    public float zMin, yMax;

    private int _enemyAlive;
    private void Start()
    {
        Spawn();
    }
    private void Update()
    {
        CurrentEnemy.RemoveAll(item => item == null);
        if (CurrentEnemy.Count == 0)
        {
            Spawn();
        }  
    }
    public void Spawn()
    {
        for (_enemyAlive = 0; _enemyAlive < 5; _enemyAlive++)
        {
            var Enemy = Instantiate(this.Enemy, new Vector3(Random.Range(2f, 17f), 0f, Random.Range(zMin, yMax)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            CurrentEnemy.Add(Enemy);
        }
    }
    public void DestroyEnemy()
    {
        for (int i = 0; i < CurrentEnemy.Count; i++)
        {
            Destroy(CurrentEnemy[i]);
        }
        CurrentEnemy.Clear();
    }
}