using UnityEngine;

public class Hint : InteractableObject
{
    [SerializeField] Dialogue dialogue;

    private void OnEnable()
    {
        dialogue.onDialogueEnd.AddListener(OnDialogueEnd);
    }


    void OnDialogueEnd()
    {
        // TEST
        TryGetComponent(out SpriteRenderer component);
        Color temp = component.color;
        temp.a = 0.2f;
        component.color = temp;
    }

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
        transform.localScale = Vector3.one;
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
        transform.localScale = Vector3.one * .75f;
    }

    public override void OnPointerClick()
    {
        base.OnPointerClick();
        dialogue.gameObject.SetActive(true);
        transform.localScale = Vector3.one * .75f;

    }

}
