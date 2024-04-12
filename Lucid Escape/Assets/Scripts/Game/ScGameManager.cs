using System.Collections;
using UnityEngine;

public class ScGameManager : MonoBehaviour
{
    public ScGameScene currentScene;
    public ScDialogueBoxController dialogueBox;
    public ScBackgroundController backgroundController;
    public ScChooseController chooseController;

    private State _state = State.IDLE;

    private enum State
    {
        IDLE,
        ANIMATE,
        CHOOSE
    }

    void Start()
    {
        if (currentScene is ScStoryScene)
        {
            ScStoryScene storyScene = currentScene as ScStoryScene;
            dialogueBox.PlayScene(storyScene);
            backgroundController.SetImage(storyScene.background);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (_state == State.IDLE && dialogueBox.IsCompleted())
            {
                if(dialogueBox.IsLastSentence()) 
                {
                    PlayScene((currentScene as ScStoryScene).nextScene);
                }
                else
                {
                    dialogueBox.PlayNextSentence();
                }
            }
        }
    }

    public void PlayScene(ScGameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(ScGameScene scene)
    {
        _state = State.ANIMATE;
        currentScene = scene;
        dialogueBox.Hide();
        if (scene is ScStoryScene)
        {
            ScStoryScene storyScene = scene as ScStoryScene;
            yield return new WaitForSeconds(1f);
            backgroundController.SwitchBackground(storyScene.background);
            yield return new WaitForSeconds(1f);
            dialogueBox.ClearText();
            dialogueBox.Show();
            yield return new WaitForSeconds(1f);
            dialogueBox.PlayScene(storyScene);
            _state = State.IDLE;
        }
        else if (scene is ScChooseScene)
        {
            _state = State.CHOOSE;
            chooseController.SetupChoose(scene as ScChooseScene);
        }
    }
}
