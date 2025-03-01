using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance;
    private Image fadePanel;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        FindFadePanel(); // 씬이 시작될 때 fadePanel을 찾음
        StartCoroutine(FadeIn());
    }

    private void FindFadePanel()
    {
        GameObject panelObj = GameObject.Find("FadePanel"); // FadePanel 다시 찾기
        if (panelObj != null)
        {
            fadePanel = panelObj.GetComponent<Image>();
            fadePanel.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("FadePanel을 찾을 수 없습니다. 씬에 FadePanel이 있는지 확인하세요!");
        }
    }

    public void FadeOutAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        FindFadePanel(); // 씬이 바뀔 때마다 FadePanel을 다시 찾음

        if (fadePanel == null) yield break; // fadePanel이 없으면 실행 중지

        fadePanel.gameObject.SetActive(true);
        yield return StartCoroutine(FadeOut());

        yield return SceneManager.LoadSceneAsync(sceneName);

        FindFadePanel(); // 새로운 씬에서 fadePanel 다시 찾기
        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            if (fadePanel != null)
                fadePanel.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            if (fadePanel != null)
                fadePanel.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }
        if (fadePanel != null) fadePanel.gameObject.SetActive(false);
    }
}
