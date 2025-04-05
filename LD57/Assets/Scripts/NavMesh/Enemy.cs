using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private AudioSource audioSource;
    private Transform target;
    private NavMeshAgent agent;
    private Vector3 originalScale;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        target = FindAnyObjectByType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation= false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        originalScale = transform.localScale;
    }
    private void Update()
    {
        Vector3 direction = target.position - transform.position;

        if (direction.x > 0.1f)
            transform.localScale = originalScale;
        else if (direction.x < -0.1f)
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            audioSource.Play();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player)) 
        {
            //audioSource.volume += Time.deltaTime / 5;
            agent.speed = speed;
            agent.SetDestination(target.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            //audioSource.volume = 0;
            audioSource.Stop();
        }
    }
}
