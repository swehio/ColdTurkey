using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [Header("페이드 UI")]
    public GameObject fadePanel; // 검은색 패널 오브젝트
    public Image fadeImage; // 페이드 효과를 줄 이미지
    public float fadeDuration = 1f; // 페이드 효과 지속 시간

    private void Start()
    {
        fadePanel.SetActive(true); // 처음에는 활성화 (페이드인 진행)
        StartCoroutine(FadeIn());
    }

    public void LoadSceneWithFade(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        fadePanel.SetActive(true); // 씬 변경 전 패널 활성화
        yield return StartCoroutine(FadeOut());

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false; // 씬 전환 대기

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f) // 씬 로딩이 90% 완료되면
            {
                yield return new WaitForSeconds(0.5f); // 약간 대기 후 씬 전환
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color fadeColor = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = fadeColor;
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color fadeColor = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = 1f - Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = fadeColor;
            yield return null;
        }

        fadePanel.SetActive(false); // 페이드인 끝나면 패널 비활성화
    }
}
