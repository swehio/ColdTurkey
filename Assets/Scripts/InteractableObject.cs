using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] UnityEvent onPointerEnter;
    [SerializeField] UnityEvent onPointerExit;
    [SerializeField] UnityEvent onPointerClick;


    public virtual void OnPointerEnter()
    {
        print("Pointer Enter " + name);
        onPointerEnter?.Invoke();
    }
    public virtual void OnPointerExit()
    {
        print("Pointer Exit " + name);
        onPointerExit?.Invoke();
    }
    public virtual void OnPointerClick()
    {
        print("Pointer Click");
        onPointerClick?.Invoke();
    }

}
