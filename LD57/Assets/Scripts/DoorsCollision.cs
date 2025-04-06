using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsCollision : MonoBehaviour
{
    [SerializeField] private LeakyDoor door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            print(player.name);
            if (door.isCloset == false)
            {
                door.CloseDoor();
            }
        }
    }
}
