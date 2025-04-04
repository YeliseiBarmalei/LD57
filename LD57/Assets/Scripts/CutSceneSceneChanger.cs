using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneSceneChanger : MonoBehaviour
{
    [SerializeField] private string scene;
    private void OnEnable()
    {
        LoadScene();
    }
    private void LoadScene() 
    {
        SceneManager.LoadScene(scene);
    }
    public void UISceneLoader(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
}
