using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] UnityEvent onPointerEnter;
    [SerializeField] UnityEvent onPointerExit;
    [SerializeField] UnityEvent onPointerClick;


    public virtual void OnPointerEnter()
    {
        onPointerEnter?.Invoke();
    }
    public virtual void OnPointerExit()
    {
        onPointerExit?.Invoke();
    }
    public virtual void OnPointerClick()
    {
        onPointerClick?.Invoke();
    }

}
