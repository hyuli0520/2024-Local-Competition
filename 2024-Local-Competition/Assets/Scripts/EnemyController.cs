using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        _boxCollider = GetComponent<BoxCollider>();
        _speed = 20;
    }

    void Update()
    {
        if (GameManager.instance._isStart)
        {
            agent.speed = _speed;
            agent.SetDestination(target.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            _boxCollider.isTrigger = true;
        }
    }
}
