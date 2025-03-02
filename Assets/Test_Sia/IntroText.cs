using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour
{
    [Header("📜 줄거리 데이터")]
    public DialogueData dialogueData;  // ScriptableObject 연결

    [Header("📝 UI 요소")]
    public TextMeshProUGUI introText;  // TMP UI 텍스트
    public TMP_FontAsset customFont;   // ✅ 사용할 SDF 폰트 (쿠키런 폰트)

    [Header("🎛 타이핑 속도")]
    public float typingSpeed = 0.05f;  // 한 글자 출력 속도

    private int currentTextIndex = 0;  // 현재 출력 중인 텍스트 인덱스

    private void Start()
    {
        if (dialogueData == null || dialogueData.Strings.Length == 0)
        {
            Debug.LogError("🚨 줄거리 데이터가 없습니다!");
            return;
        }

        // ✅ TMP가 강제적으로 서브 메쉬를 추가하지 못하게 설정
        introText.enableAutoSizing = false; // 자동 크기 조정 방지
        introText.richText = false;  // 리치 텍스트 비활성화

        // ✅ 모든 텍스트에서 쿠키런 폰트 강제 적용
        if (customFont != null)
        {
            introText.font = customFont; // ✅ SDF 폰트 강제 적용
        }
        else
        {
            Debug.LogWarning("⚠️ TMP SDF 폰트가 설정되지 않았습니다! 기본 폰트 사용.");
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
            
            // ✅ 출력될 때마다 다시 한 번 폰트 적용 (LiberationSans 강제 변경 방지)
            introText.font = customFont;

            foreach (char letter in currentText)
            {
                introText.text += letter;  // 한 글자씩 추가
                yield return new WaitForSeconds(typingSpeed);  // 타이핑 속도 적용
            }

            yield return new WaitForSeconds(1.5f);  // 다음 문장 전 대기
            currentTextIndex++;  // 다음 문장으로 이동
        }

        // 🔄 모든 텍스트 출력 후 자동으로 씬 이동 가능
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("3_YSA_Menu");  
    }
}
