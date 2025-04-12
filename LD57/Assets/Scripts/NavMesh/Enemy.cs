using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed;
    [SerializeField] private AudioClip audioClip;
    public AudioSource audioSource;
    public Transform target;
    public NavMeshAgent agent;

    private Vector3 originalScale;

    [Header("Damage Settings")]
    [SerializeField] private float damageCooldown = 1.5f;
    private float nextTimeToDamage = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        target = FindAnyObjectByType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        originalScale = transform.localScale;
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;

        if (direction.x > 0.1f)
            transform.localScale = originalScale;
        else if (direction.x < -0.1f)
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryDamage(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TryDamage(collision);
    }

    private void TryDamage(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (Time.time >= nextTimeToDamage)
            {
                player.currentHp--;
                audioSource.PlayOneShot(audioClip);
                nextTimeToDamage = Time.time + damageCooldown;
            }
        }
    }
}
