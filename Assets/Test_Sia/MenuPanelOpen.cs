using UnityEngine;

public class MenuPanelOpen : MonoBehaviour
{
    public GameObject currentPanel; // 현재 위치한 지역 패널
    public GameObject impossiblePanel; // 지역을 옮길 수 없다는 패널
    public GameObject exitPanel; // 종료 패널
    public GameObject InblockerPanel; // 내부 클릭 차단 패널 (메뉴 내 버튼용)

    // ========== 메뉴 내부 버튼 ========== 
    public void CurrentLocation()
    {
        bool isActive = !currentPanel.activeSelf;
        InblockerPanel.SetActive(isActive); // ✅ 전체 클릭 차단
        currentPanel.SetActive(isActive);
    }
    public void ImpossibleLocation()
    {
        bool isActive = !impossiblePanel.activeSelf;
        InblockerPanel.SetActive(isActive); // ✅ 전체 클릭 차단
        impossiblePanel.SetActive(isActive);
    }

    public void MenuExitMenu()
    {
        bool isActive = !exitPanel.activeSelf;
        InblockerPanel.SetActive(isActive); // ✅ 전체 클릭 차단
        exitPanel.SetActive(isActive);
    }

    // ========== 패널 닫기 버튼 ========== 
    public void CloseCurrent()
    {
        currentPanel.SetActive(false);
        InblockerPanel.SetActive(false);
    }
    public void CloseImpossible()
    {
        impossiblePanel.SetActive(false);
        InblockerPanel.SetActive(false);
    }

    public void CloseExitMenu()
    {
        exitPanel.SetActive(false);
        InblockerPanel.SetActive(false);
    }


}
