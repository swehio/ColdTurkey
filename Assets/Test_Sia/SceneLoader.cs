using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        FadeManager.Instance.LoadSceneWithFade(sceneName);
    }
}
