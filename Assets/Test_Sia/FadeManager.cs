using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance; // 싱글톤 패턴 적용

    [Header("페이드 UI")]
    public GameObject fadePanel; // 검은색 패널 오브젝트
    public Image fadeImage; // 페이드 효과를 줄 이미지
    public float fadeDuration = 1f; // 페이드 효과 지속 시간

    private void Awake()
    {
        // 싱글톤 패턴 적용 (씬 전환 시에도 유지)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ✅ FadeManager 유지
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(fadePanel); // ✅ FadePanel도 유지되도록 설정
        fadePanel.SetActive(true); // ✅ 처음에는 활성화 (페이드인 진행)
    }

    private void Start()
    {
        StartCoroutine(FadeIn()); // 씬 시작 시 페이드인 효과 적용
    }

    public void LoadSceneWithFade(string sceneName)
    {
        StartCoroutine(FadeOutAndChangeScene(sceneName));
    }

    IEnumerator FadeOutAndChangeScene(string sceneName)
    {
        fadePanel.SetActive(true); // ✅ 씬 변경 전 패널 활성화
        yield return StartCoroutine(FadeOut());

        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(0.1f); // 씬이 완전히 로드될 시간을 약간 줌

        yield return StartCoroutine(FadeIn());
        fadePanel.SetActive(false); // ✅ 페이드인 완료 후 비활성화
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

        fadePanel.SetActive(false); // ✅ 페이드인 끝나면 패널 비활성화
    }
}
