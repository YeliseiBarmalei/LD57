using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Enemy enemy;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out PlayerController player))
        {
            enemy.audioSource.Play();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            //audioSource.volume += Time.deltaTime / 5;
            enemy.agent.speed = enemy.speed;
            if (enemy.agent.isOnNavMesh)
            {
                enemy.agent.SetDestination(enemy.target.position);
            }
            else
            {
                Debug.LogWarning("Агент не на NavMesh!");
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            //audioSource.volume = 0;
            enemy.audioSource.Stop();
        }
    }
}
