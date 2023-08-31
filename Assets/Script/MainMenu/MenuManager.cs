using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject confirmPanel;
    public Button StartBtn;
    public Button ExitBtn;
    public Button YesBtn;
    public Button NoBtn;
    // Start is called before the first frame update
    void Start()
    {
        // Hide the confirm panel initially
        confirmPanel.SetActive(false);
        StartBtn.onClick.AddListener(LoadNewScene);
        ExitBtn.onClick.AddListener(ShowConfirmPanel);
        YesBtn.onClick.AddListener(YesButtonClicked);
        NoBtn.onClick.AddListener(NoButtonClicked);
    }

    public void ShowConfirmPanel()
    {
        // Show the confirm panel with the specified message
        confirmPanel.SetActive(true);
    }

    public void YesButtonClicked()
    {
        // Handle the "Yes" button click
        // Add your code here to exit the game or perform any other desired action
        Application.Quit();
    }

    public void NoButtonClicked()
    {
        // Handle the "No" button click
        confirmPanel.SetActive(false);
    }

    public void LoadNewScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
