using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Character
{
    private NavMeshAgent agent;

    [SerializeField]
    private Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _speed = 10;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
