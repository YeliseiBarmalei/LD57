using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform target;
    NavMeshAgent agent;
    void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation= false;
        agent.updateUpAxis = false;
        agent.speed = speed; 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player)) 
        {
            agent.SetDestination(target.position);
        }
    }
}
