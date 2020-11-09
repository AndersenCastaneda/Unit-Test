using UnityEngine;

[CreateAssetMenu(fileName = "IntRefference", menuName = "IntRefference")]
public class IntRefference : ScriptableObject
{
    [Range(0, 100)]
    public int value;
}
