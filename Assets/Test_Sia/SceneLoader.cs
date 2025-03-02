using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        FadeManager fadeManager = FindFirstObjectByType<FadeManager>(); // ���ο� ��� ����

        if (fadeManager != null)
        {
            fadeManager.LoadSceneWithFade(sceneName); // ���̵�ƿ� �� �� ����
        }
        else
        {
            SceneManager.LoadScene(sceneName); // FadeManager ������ �׳� �� ����
        }
    }
}
