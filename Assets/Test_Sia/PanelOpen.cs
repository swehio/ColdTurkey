using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject optionPanel; // 옵션 패널 연결할 변수
    public GameObject savePanel; // 옵션 패널 연결할 변수
    public GameObject blockerPanel;   // 클릭 차단용 패널

    public void ToggleOptionMenu()
    {
        bool isActive = !optionPanel.activeSelf;
        // 옵션 패널의 활성/비활성 상태를 전환
        blockerPanel.SetActive(isActive); // 패널이 열릴 때만 클릭 차단 활성화
        optionPanel.SetActive(isActive);
        savePanel.SetActive(false); // 이어하기 창은 닫힘
    }
    public void ToggleSaveMenu()
    {
        bool isActive = !savePanel.activeSelf;
        // 옵션 패널의 활성/비활성 상태를 전환
        blockerPanel.SetActive(isActive); // 패널이 열릴 때만 클릭 차단 활성화
        savePanel.SetActive(isActive);
        optionPanel.SetActive(false); // 옵션 창은 닫힘
    }
    // 옵션 창 닫기
    public void CloseOptionMenu()
    {
        optionPanel.SetActive(false);
        blockerPanel.SetActive(false); // 닫힐 때 차단 해제
    }

    // 이어하기 창 닫기
    public void CloseSaveMenu()
    {
        savePanel.SetActive(false);
        blockerPanel.SetActive(false); // 닫힐 때 차단 해제
    }
}
