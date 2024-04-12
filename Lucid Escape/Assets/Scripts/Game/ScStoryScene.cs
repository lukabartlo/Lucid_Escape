using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/NewStoryScene")]
[System.Serializable]

public class ScStoryScene : ScGameScene
{
    public List<Sentence> sentences;
    public Sprite background;
    public ScGameScene nextScene;

    [System.Serializable]

    public struct Sentence
    {
        public string text;
        public ScCharacterTalking character;
    }
}

public class ScGameScene : ScriptableObject { }