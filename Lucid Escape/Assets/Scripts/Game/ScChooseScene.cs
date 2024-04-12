using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChooseScene", menuName = "Data/NewChooseScene")]
[System.Serializable]

public class ScChooseScene : ScGameScene
{
    public List<ChooseLabel> labels;

    [System.Serializable]

    public struct ChooseLabel
    {
        public string text;
        public ScStoryScene nextScene;
    }
}
