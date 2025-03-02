using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject optionPanel; // 옵션 패널 연결할 변수
    public GameObject savePanel; // 이어하기 패널 연결할 변수
    public GameObject exitPanel; // 이어하기 패널 연결할 변수
    public GameObject blockerPanel;   // 클릭 차단용 패널
    public GameObject menuPanel; // 메뉴 패널 연결할 변수

    public void ToggleOptionMenu()
    {
        bool isActive = !optionPanel.activeSelf;
        // 옵션 패널의 활성/비활성 상태를 전환
        blockerPanel.SetActive(isActive); // 패널이 열릴 때만 클릭 차단 활성화
        optionPanel.SetActive(isActive);
        savePanel.SetActive(false); // 이어하기 창은 닫힘
        exitPanel.SetActive(false); // 종료 창은 닫힘
    }
    public void ToggleSaveMenu()
    {
        bool isActive = !savePanel.activeSelf;
        // 게임방법 패널의 활성/비활성 상태를 전환
        blockerPanel.SetActive(isActive); // 패널이 열릴 때만 클릭 차단 활성화
        savePanel.SetActive(isActive);
        optionPanel.SetActive(false); // 옵션 창은 닫힘
        exitPanel.SetActive(false); // 종료 창은 닫힘
    }
    public void ToggleExitMenu()
    {
        bool isActive = !exitPanel.activeSelf;
        // 옵션 패널의 활성/비활성 상태를 전환
        blockerPanel.SetActive(isActive); // 패널이 열릴 때만 클릭 차단 활성화
        exitPanel.SetActive(isActive);
        savePanel.SetActive(false); // 이어하기 창은 닫힘
        optionPanel.SetActive(false); // 옵션 창은 닫힘
    }
    public void ToggleMenu()
    {
        bool isActive = !menuPanel.activeSelf;
        // 메뉴 패널의 활성/비활성 상태를 전환
        blockerPanel.SetActive(isActive); // 패널이 열릴 때만 클릭 차단 활성화
        menuPanel.SetActive(isActive);
        //savePanel.SetActive(false); // 이어하기 창은 닫힘
        //optionPanel.SetActive(false); // 옵션 창은 닫힘
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
        blockerPanel.SetActive(false); 
    }
    // 종료 창 닫기
    public void CloseExitMenu()
    {
        exitPanel.SetActive(false);
        blockerPanel.SetActive(false); 
    }
    public void CloseMenu()
    {
        menuPanel.SetActive(false);
        blockerPanel.SetActive(false);
    }
}
