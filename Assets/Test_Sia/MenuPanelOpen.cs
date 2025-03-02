using UnityEngine;

public class MenuPanelOpen : MonoBehaviour
{
    public GameObject exitPanel; // 종료 패널
    public GameObject InblockerPanel; // 내부 클릭 차단 패널 (메뉴 내 버튼용)

    // ========== 메뉴 내부 버튼 ========== 


    public void MenuExitMenu()
    {
        bool isActive = !exitPanel.activeSelf;
        InblockerPanel.SetActive(isActive); // ✅ 전체 클릭 차단
        exitPanel.SetActive(isActive);
    }

    // ========== 패널 닫기 버튼 ========== 
  

    public void CloseExitMenu()
    {
        exitPanel.SetActive(false);
        InblockerPanel.SetActive(false);
    }


}
