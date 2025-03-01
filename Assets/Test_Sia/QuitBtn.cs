using UnityEngine;

public class QuitBtn : MonoBehaviour
{
    public void ExitGame()
    {
        // 게임 빌드 상태에서 종료
        Application.Quit();

        // Unity 에디터에서 실행 중이라면 실행 종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
