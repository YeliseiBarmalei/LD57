using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Лучше использовать GetKeyDown, чтобы не срабатывало постоянно
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
