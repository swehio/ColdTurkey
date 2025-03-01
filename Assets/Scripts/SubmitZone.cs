using UnityEngine;

public class SubmitZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Draggable")) 
        {

        }
    }
}
