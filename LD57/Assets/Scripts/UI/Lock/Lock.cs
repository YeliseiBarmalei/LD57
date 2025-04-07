using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] GameObject lockUI;
    private bool isAbleToOpenPanel;
    private void Update()
    {
        if (lockUI.GetComponent<LockCode>().codeIsCorrect) 
        {
            Destroy(lockUI);
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E) && isAbleToOpenPanel)
        {
            lockUI.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            isAbleToOpenPanel = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            isAbleToOpenPanel = false;
        }
    }
}
