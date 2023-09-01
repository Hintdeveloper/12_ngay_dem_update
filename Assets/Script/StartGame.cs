using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Button StartBtn;
    void Start()
    {
        StartBtn.onClick.AddListener(LoadNewSence);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadNewSence()
    {
        SceneManager.LoadScene(2);
    }
}
