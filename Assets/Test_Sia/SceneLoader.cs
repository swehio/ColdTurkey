using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        FadeManager fadeManager = FindFirstObjectByType<FadeManager>(); // 새로운 방식 적용

        if (fadeManager != null)
        {
            fadeManager.LoadSceneWithFade(sceneName); // 페이드아웃 후 씬 변경
        }
        else
        {
            SceneManager.LoadScene(sceneName); // FadeManager 없으면 그냥 씬 변경
        }
    }
}
