using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public GameObject winUI;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Win()
    {
        winUI.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSubLevel()
    {
        SceneManager.LoadScene(5);
    }
    public void SenceGuideNext()
    {
        SceneManager.LoadScene(3);
    }

}
