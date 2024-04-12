using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject _options;
    [SerializeField] private GameObject _credits;

    public void StartGame()
    {
        SceneManager.LoadScene("DevScene");
    }

    public void OpenOptions()
    {
        _options.SetActive(true);
    }

    public void CloseOptions()
    {
        _options.SetActive(false);
    }

    public void OpenCredits()
    {
        _credits.SetActive(true);
    }

    public void CloseCredits()
    {
        _credits.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}