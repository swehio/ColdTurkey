using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "SO/DialogueData")]
public class DialogueData : ScriptableObject
{
    [field: SerializeField] public string[] Strings { get; private set; }
    [field: SerializeField] public float Interval { get; private set; }
}
