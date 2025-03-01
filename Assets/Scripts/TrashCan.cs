using UnityEngine;

public class TrashCan : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Draggable")) // 특정 태그가 있는 오브젝트만 삭제
        {
            Debug.Log($"{other.gameObject.name}이(가) 쓰레기통에 버려졌습니다!");
            Destroy(other.gameObject);
        }
    }
}