using UnityEngine;

[CreateAssetMenu(fileName = "Responses", menuName = "SO/Responses")]
public class Responses : ScriptableObject
{
    [field: SerializeField] public string[] Strings { get; private set; }
}