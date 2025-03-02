using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroTextManager : MonoBehaviour
{
    [Header("줄거리 데이터")]
    public DialogueData dialogueData; // ScriptableObject 연결

    [Header("UI 요소")]
    public Text introText; // 기존 UI Text 사용

    [Header("타이핑 속도")]
    public float typingSpeed = 0.05f; // 한 글자 출력 속도

    private int currentTextIndex = 0; // 현재 출력 중인 텍스트 인덱스
    public string nextSceneName = "3_YSA_MenuPopup"; // 이동할 씬 이름 (나중에 변경 가능)

    private void Start()
    {
        if (dialogueData == null || dialogueData.Strings.Length == 0)
        {
            Debug.LogError("줄거리 데이터가 연결되지 않았거나 비어 있습니다!");
            return;
        }

        introText.text = ""; // 초기화
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        while (currentTextIndex < dialogueData.Strings.Length)
        {
            introText.text = ""; // 기존 텍스트 초기화
            string currentText = dialogueData.Strings[currentTextIndex];

            foreach (char letter in currentText)
            {
                introText.text += letter; // 한 글자씩 추가
                yield return new WaitForSeconds(typingSpeed); // 타이핑 속도 적용
            }

            yield return new WaitForSeconds(1.5f); // 다음 문장 전 대기
            currentTextIndex++; // 다음 문장으로 이동
        }

        // 모든 텍스트 출력 후 페이드인 + 비동기 씬 전환
        yield return new WaitForSeconds(2f);

        FadeManager fadeManager = FindFirstObjectByType<FadeManager>(); // FadeManager 찾기
        if (fadeManager != null)
        {
            fadeManager.LoadSceneWithFade(nextSceneName); // 페이드 효과 후 비동기 씬 이동
        }
        else
        {
            StartCoroutine(LoadSceneAsync(nextSceneName)); // FadeManager 없으면 비동기 씬 전환
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
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
}
