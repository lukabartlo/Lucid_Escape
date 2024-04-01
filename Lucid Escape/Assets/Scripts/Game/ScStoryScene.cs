using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/NewStoryScene")]
[System.Serializable]

public class ScStoryScene : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite background;
    public ScStoryScene nextScene;

    [System.Serializable]

    public struct Sentence
    {
        public string text;
        public ScCharacterTalking character;
    }
}
