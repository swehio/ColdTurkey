using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject optionPanel; // �ɼ� �г� ������ ����
    public GameObject savePanel; // �ɼ� �г� ������ ����

    public void ToggleOptionMenu()
    {
        // �ɼ� �г��� Ȱ��/��Ȱ�� ���¸� ��ȯ
        optionPanel.SetActive(!optionPanel.activeSelf);
        savePanel.SetActive(false); // �̾��ϱ� â�� ����
    }
    public void ToggleSaveMenu()
    {
        // �ɼ� �г��� Ȱ��/��Ȱ�� ���¸� ��ȯ
        savePanel.SetActive(!savePanel.activeSelf);
        optionPanel.SetActive(false); // �ɼ� â�� ����
    }
    // �ɼ� â �ݱ�
    public void CloseOptionMenu()
    {
        optionPanel.SetActive(false);
    }

    // �̾��ϱ� â �ݱ�
    public void CloseSaveMenu()
    {
        savePanel.SetActive(false);
    }
}
