using System.Collections;
using TMPro;
using UnityEngine;

public class ScDialogueBoxController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI personNameText;

    private int _sentenceIndex = -1;
    private ScStoryScene _currentScene;
    private State _state = State.COMPLETED;
    private  Animator animator;
    private bool _isHidden = false;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private enum State
    {
        PLAYING,
        COMPLETED
    }

    public void Hide()
    {
        if (!_isHidden)
        {
            animator.SetTrigger("Hide");
            _isHidden = true;
        }
    }

    public void ClearText()
    {
        dialogueText.text = "";
    }

    public void Show()
    {
        animator.SetTrigger("Show");
        _isHidden = false;
    }

    public void PlayScene(ScStoryScene scene)
    {
        _currentScene = scene;
        _sentenceIndex = -1;
    }

    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(_currentScene.sentences[++_sentenceIndex].text));
        personNameText.text = _currentScene.sentences[_sentenceIndex].character.characterName;
        personNameText.color = _currentScene.sentences[_sentenceIndex].character.textColor;
    }

    public bool IsCompleted()
    {
        return _state == State.COMPLETED; 
    }

    public bool IsLastSentence()
    {
        return _sentenceIndex + 1 == _currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string textDialogue)
    {
        dialogueText.text = "";
        _state = State.PLAYING;
        int wordIndex = 0;

        while (_state != State.COMPLETED) 
        { 
            dialogueText.text += textDialogue[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if(++wordIndex == textDialogue.Length)
            {
                _state = State.COMPLETED;
                break;
            }
        }
    }


}
