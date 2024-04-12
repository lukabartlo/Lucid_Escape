using UnityEngine;
using TMPro;

public class ScChooseController : MonoBehaviour
{
    public ScChooseLabelController label;
    public ScGameManager gameManager;
    public Vector2 sizeDelta;

    private RectTransform _rectTransform;
    private Animator _animator;
    private float _labelHeight = -1;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetupChoose(ScChooseScene scene)
    {
        DestroyLabels();
        _animator.SetTrigger("Show");
        for(int index = 0; index < scene.labels.Count; index++)
        {
            ScChooseLabelController newLabel = Instantiate(label.gameObject, transform).GetComponent<ScChooseLabelController>();

            if(_labelHeight == -1)
            {
                _labelHeight = newLabel.GetHeight();
            }

            newLabel.Setup(scene.labels[index], this, CalculateLabelPosition(index, scene.labels.Count));
        }
        Vector2 size = _rectTransform.sizeDelta;
        size.y = (scene.labels.Count + 2) * _labelHeight;
        _rectTransform.sizeDelta = size;
    }

    public void PerformChoose(ScStoryScene scene)
    {
        gameManager.PlayScene(scene);
        _animator.SetTrigger("Hide");
    }

    private float CalculateLabelPosition(int labelIndex, int labelCount)
    {
        if (labelCount %2 == 0)
        {
            if(labelIndex < labelCount / 2)
            {
                return _labelHeight * (labelCount /2 - labelIndex - 1) + _labelHeight / 2;
            }
            else
            {
                return -1 * (_labelHeight * (labelIndex - labelCount / 2) + _labelHeight / 2);
            }
        }
        else
        {
            if (labelIndex < labelCount / 2)
            {
                return _labelHeight * (labelCount / 2 - labelIndex - 1) + _labelHeight / 2;
            }
            else if (labelIndex > labelCount / 2)
            {
                return -1 * (_labelHeight * (labelIndex - labelCount / 2));
            }
            else
            {
                return 0;
            }
        }
    }
    
    private void DestroyLabels()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }
}
