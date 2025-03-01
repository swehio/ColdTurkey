using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject optionPanel; // �ɼ� �г� ������ ����
    public GameObject savePanel; // �̾��ϱ� �г� ������ ����
    public GameObject exitPanel; // �̾��ϱ� �г� ������ ����
    public GameObject blockerPanel;   // Ŭ�� ���ܿ� �г�

    public void ToggleOptionMenu()
    {
        bool isActive = !optionPanel.activeSelf;
        // �ɼ� �г��� Ȱ��/��Ȱ�� ���¸� ��ȯ
        blockerPanel.SetActive(isActive); // �г��� ���� ���� Ŭ�� ���� Ȱ��ȭ
        optionPanel.SetActive(isActive);
        savePanel.SetActive(false); // �̾��ϱ� â�� ����
        exitPanel.SetActive(false); // ���� â�� ����
    }
    public void ToggleSaveMenu()
    {
        bool isActive = !savePanel.activeSelf;
        // �ɼ� �г��� Ȱ��/��Ȱ�� ���¸� ��ȯ
        blockerPanel.SetActive(isActive); // �г��� ���� ���� Ŭ�� ���� Ȱ��ȭ
        savePanel.SetActive(isActive);
        optionPanel.SetActive(false); // �ɼ� â�� ����
        exitPanel.SetActive(false); // ���� â�� ����
    }
    public void ToggleExitMenu()
    {
        bool isActive = !exitPanel.activeSelf;
        // �ɼ� �г��� Ȱ��/��Ȱ�� ���¸� ��ȯ
        blockerPanel.SetActive(isActive); // �г��� ���� ���� Ŭ�� ���� Ȱ��ȭ
        exitPanel.SetActive(isActive);
        savePanel.SetActive(false); // �̾��ϱ� â�� ����
        optionPanel.SetActive(false); // �ɼ� â�� ����
    }
    // �ɼ� â �ݱ�
    public void CloseOptionMenu()
    {
        optionPanel.SetActive(false);
        blockerPanel.SetActive(false); // ���� �� ���� ����
    }

    // �̾��ϱ� â �ݱ�
    public void CloseSaveMenu()
    {
        savePanel.SetActive(false);
        blockerPanel.SetActive(false); 
    }
    // ���� â �ݱ�
    public void CloseExitMenu()
    {
        exitPanel.SetActive(false);
        blockerPanel.SetActive(false); 
    }
}
