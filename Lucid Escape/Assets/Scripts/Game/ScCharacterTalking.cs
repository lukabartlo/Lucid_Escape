using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter",menuName = "Data/NewCharacter")]
[System.Serializable]

public class ScCharacterTalking : ScriptableObject
{
    public string characterName;
    public Color textColor;
}
