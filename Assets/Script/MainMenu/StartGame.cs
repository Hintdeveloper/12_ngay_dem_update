using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startBtn;
    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(LoadNewScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
