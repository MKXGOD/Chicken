using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private GameObject _chiken;

    private float _distanceAttack;
    private float _viewRadius = 2f;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _chiken = GameObject.Find("ToonChicken");
    }
    private void Update()
    {
        _distanceAttack = Vector3.Distance(transform.position, _chiken.transform.position);
        Chase();
    }
    private void Chase()
    {
        if (_distanceAttack < _viewRadius)
        {
            _navMeshAgent.enabled = true;
            _navMeshAgent.SetDestination(_chiken.transform.position);
        }
        else if(_distanceAttack > _viewRadius)
            _navMeshAgent.enabled = false;
    }
}
