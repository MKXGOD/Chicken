using System;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI
{
    private NavMeshAgent _agent;
    private Collider[] _withinEnemyColliders;
    private LayerMask _playerLayer;

    private float _viewRadius;
    public enum Type
    { 
        _isPeaceful,
        _isAggressive
    }
    private Type _type;

    public EnemyAI(NavMeshAgent agent, LayerMask layerMask, Type type,float speed, float angularSpeed, float viewRadius)
    { 
        _agent = agent;
        _playerLayer = layerMask;
        _type = type;
        _agent.speed = speed;
        _agent.angularSpeed = angularSpeed;
        _viewRadius = viewRadius;
    }

    public void View(Transform viewer)
    {
        
        _withinEnemyColliders = Physics.OverlapSphere(viewer.position, _viewRadius, _playerLayer);

        if (_withinEnemyColliders.Length > 0)
        { 
            _agent.enabled = true;
            var player = _withinEnemyColliders[0].GetComponent<Transform>();

            if (_type == Type._isPeaceful)
                RunAway(viewer, player);
            else Attack(viewer, player);
        }
        else _agent.enabled = false;
    }

    private void Attack(Transform viewer, Transform player)
    {
        _agent.SetDestination(player.position);
        if (_agent.velocity != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(-_agent.velocity, Vector3.up);
            viewer.rotation = Quaternion.Lerp(viewer.rotation, rotation, Time.deltaTime * _agent.angularSpeed * 1.5f);
        }
    }

    private void RunAway(Transform viewer, Transform player)
    {
        Vector3 destination = (viewer.position - player.position) + viewer.position;
        if (_agent.velocity != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(-_agent.velocity, Vector3.up);
            viewer.rotation = Quaternion.Lerp(viewer.rotation, rotation, Time.deltaTime * _agent.angularSpeed);
        }
        _agent.SetDestination(destination);
    }
}
