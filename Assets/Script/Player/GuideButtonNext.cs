using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideButtonNext : MonoBehaviour
{
    public GameObject ButtonNext;
    public int durationButton;
    // Start is called before the first frame update
    void Start()
    {
        ButtonNext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckConditions(durationButton);
    }
    public void CheckConditions(int second) 
    {
        StartCoroutine(TimerButton());
    }
    IEnumerator TimerButton()
    {
        yield return new WaitForSeconds(durationButton);
        EndtimerButton();
    }
    void EndtimerButton()
    {
        ButtonNext.SetActive(true);
    }
}
