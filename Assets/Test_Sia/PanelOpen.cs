using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject optionPanel; // 옵션 패널
    public GameObject HowtoPanel; // 게임방법 패널
    public GameObject exitPanel; // 종료 패널
    public GameObject blockerPanel; // 전체 클릭 차단 패널
    public GameObject menuPanel; // 메뉴 패널
    public GameObject InblockerPanel; // 내부 클릭 차단 패널 (메뉴 내 버튼용)

    // ========== 타이틀 버튼 ========== 
    public void ToggleOptionMenu()
    {
        bool isActive = !optionPanel.activeSelf;
        blockerPanel.SetActive(isActive);
        optionPanel.SetActive(isActive);
        HowtoPanel.SetActive(false);
        exitPanel.SetActive(false);
    }

    public void ToggleHowtoMenu()
    {
        bool isActive = !HowtoPanel.activeSelf;
        blockerPanel.SetActive(isActive);
        HowtoPanel.SetActive(isActive);
        optionPanel.SetActive(false);
        exitPanel.SetActive(false);
    }

    public void ToggleExitMenu()
    {
        bool isActive = !exitPanel.activeSelf;
        blockerPanel.SetActive(isActive);
        exitPanel.SetActive(isActive);
        HowtoPanel.SetActive(false);
        optionPanel.SetActive(false);
    }

    public void ToggleMenu()
    {
        bool isActive = !menuPanel.activeSelf;
        blockerPanel.SetActive(isActive);
        menuPanel.SetActive(isActive);
    }

    // ========== 메뉴 내부 버튼 ========== 
    public void MenuOptionMenu()
    {
        bool isActive = !optionPanel.activeSelf;
        blockerPanel.SetActive(isActive); // ✅ 전체 클릭 차단
        optionPanel.SetActive(isActive);
    }

    public void MenuExitMenu()
    {
        bool isActive = !exitPanel.activeSelf;
        blockerPanel.SetActive(isActive); // ✅ 전체 클릭 차단
        exitPanel.SetActive(isActive);
    }

    // ========== 패널 닫기 버튼 ========== 
    public void CloseOptionMenu()
    {
        optionPanel.SetActive(false);
        blockerPanel.SetActive(false);
    }

    public void CloseHowtoMenu()
    {
        HowtoPanel.SetActive(false);
        blockerPanel.SetActive(false);
    }

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
