using UnityEngine;

public class LoadScene : MonoBehaviour
{

    public void LoadStartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    public void LoadGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}