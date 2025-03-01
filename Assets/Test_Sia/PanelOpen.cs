using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject optionPanel; // 옵션 패널 연결할 변수
    public GameObject savePanel; // 옵션 패널 연결할 변수

    public void ToggleOptionMenu()
    {
        // 옵션 패널의 활성/비활성 상태를 전환
        optionPanel.SetActive(!optionPanel.activeSelf);
        savePanel.SetActive(false); // 이어하기 창은 닫힘
    }
    public void ToggleSaveMenu()
    {
        // 옵션 패널의 활성/비활성 상태를 전환
        savePanel.SetActive(!savePanel.activeSelf);
        optionPanel.SetActive(false); // 옵션 창은 닫힘
    }
    // 옵션 창 닫기
    public void CloseOptionMenu()
    {
        optionPanel.SetActive(false);
    }

    // 이어하기 창 닫기
    public void CloseSaveMenu()
    {
        savePanel.SetActive(false);
    }
}
