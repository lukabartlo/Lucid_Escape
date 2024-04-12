using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScBackgroundController : MonoBehaviour
{

    public bool isSwitched;
    public Image background1;
    public Image background2;
    public Animator animator;

    public void SwitchBackground(Sprite sprite)
    {
        if (!isSwitched)
        {
            background2.sprite = sprite;
            animator.SetTrigger("SwitchFirst");
        }
        else
        {
            background1.sprite = sprite;
            animator.SetTrigger("SwitchSecond");
        }
        isSwitched = false;
    }

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            background1.sprite = sprite;

        }
        else
        {
            background2.sprite = sprite;
        }
    }
}
