using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  //  기존 UI Text 사용

public class IntroTextManager : MonoBehaviour
{
    [Header(" 줄거리 데이터")]
    public DialogueData dialogueData;  // 기존 ScriptableObject 연결

    [Header(" UI 요소")]
    public Text introText;  //  기존 UI Text 사용

    [Header(" 타이핑 속도")]
    public float typingSpeed = 0.05f;  // 한 글자 출력 속도

    private int currentTextIndex = 0;  // 현재 출력 중인 텍스트 인덱스

    private void Start()
    {
        if (dialogueData == null || dialogueData.Strings.Length == 0)
        {
            Debug.LogError(" 줄거리 데이터가 연결되지 않았거나 비어 있습니다!");
            return;
        }

        introText.text = "";  // 초기화
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        while (currentTextIndex < dialogueData.Strings.Length)
        {
            introText.text = "";  // 기존 텍스트 초기화
            string currentText = dialogueData.Strings[currentTextIndex];

            foreach (char letter in currentText)
            {
                introText.text += letter;  // 한 글자씩 추가
                yield return new WaitForSeconds(typingSpeed);  // 타이핑 속도 적용
            }

            yield return new WaitForSeconds(1.5f);  // 다음 문장 전 대기
            currentTextIndex++;  // 다음 문장으로 이동
        }

        //  모든 텍스트 출력 후 자동으로 씬 이동
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("3_YSA_Menu"); // 다음 씬으로 이동하는 코드 추가 가능
    }
}
