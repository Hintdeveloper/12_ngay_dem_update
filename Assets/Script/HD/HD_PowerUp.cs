using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HD_PowerUp : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public Button StartBtn;
    // Start is called before the first frame update
    void Start()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
        StartBtn.onClick.AddListener(LoadNewScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OffPanel1()
    {
        panel1.SetActive(false);
        OnPanel2();
    }
    public void OnPanel2()
    {
        panel2.SetActive(true);
    }
    public void LoadNewScene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
