using UnityEngine;

public class QuitBtn : MonoBehaviour
{
    public void ExitGame()
    {
        // ���� ���� ���¿��� ����
        Application.Quit();

        // Unity �����Ϳ��� ���� ���̶�� ���� ����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
