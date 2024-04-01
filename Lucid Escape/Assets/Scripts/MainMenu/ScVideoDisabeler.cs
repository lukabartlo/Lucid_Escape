using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScVideoDisabeler : MonoBehaviour
{
    [SerializeField] private GameObject _videoIntro;
    [SerializeField] private GameObject _videoMenu;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _quitButton;
    [SerializeField] private GameObject _creditsButton;
    [SerializeField] private GameObject _settingsButton;

    private void Start()
    {
        StartCoroutine(DisableIntro());
    }

    private IEnumerator DisableIntro()
    {
        _videoIntro.SetActive(true);
        _videoMenu.SetActive(false);
        _playButton.SetActive(false);
        _quitButton.SetActive(false);
        _creditsButton.SetActive(false);
        _settingsButton.SetActive(false);
        yield return new WaitForSeconds(5.5f);
        _videoIntro.SetActive(false);
        _videoMenu.SetActive(true);
        _playButton.SetActive(true);
        _quitButton.SetActive(true);
        _creditsButton.SetActive(true);
        _settingsButton.SetActive(true);
    }
}
