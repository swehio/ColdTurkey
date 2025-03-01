using UnityEngine;

public class TrashCan : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Draggable")) // Ư�� �±װ� �ִ� ������Ʈ�� ����
        {
            Debug.Log($"{other.gameObject.name}��(��) �������뿡 ���������ϴ�!");
            Destroy(other.gameObject);
        }
    }
}