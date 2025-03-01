using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject optionPanel; // �ɼ� �г� ������ ����
    public GameObject savePanel; // �ɼ� �г� ������ ����
    public GameObject blockerPanel;   // Ŭ�� ���ܿ� �г�

    public void ToggleOptionMenu()
    {
        bool isActive = !optionPanel.activeSelf;
        // �ɼ� �г��� Ȱ��/��Ȱ�� ���¸� ��ȯ
        blockerPanel.SetActive(isActive); // �г��� ���� ���� Ŭ�� ���� Ȱ��ȭ
        optionPanel.SetActive(isActive);
        savePanel.SetActive(false); // �̾��ϱ� â�� ����
    }
    public void ToggleSaveMenu()
    {
        bool isActive = !savePanel.activeSelf;
        // �ɼ� �г��� Ȱ��/��Ȱ�� ���¸� ��ȯ
        blockerPanel.SetActive(isActive); // �г��� ���� ���� Ŭ�� ���� Ȱ��ȭ
        savePanel.SetActive(isActive);
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
        blockerPanel.SetActive(false); // ���� �� ���� ����
    }
}
