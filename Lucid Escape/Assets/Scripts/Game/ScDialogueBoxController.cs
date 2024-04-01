using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScDialogueBoxController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI personNameText;

    private int _sentenceIndex = -1;
    public ScStoryScene _currentScene;
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING,
        COMPLETED
    }
    // Start is called before the first frame update
    void Start()
    {
        /*StartCoroutine(TypeText(_currentScene.sentences[++_sentenceIndex].text));*/
    }

    private IEnumerable TypeText(string text)
    {
        dialogueText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED) 
        { 
            dialogueText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
