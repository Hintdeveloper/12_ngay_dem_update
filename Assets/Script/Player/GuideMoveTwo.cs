using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideMoveTwo : MonoBehaviour
{
   
    public int durationDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CoolDown(durationDisplay);
        
        
    }
    public void CoolDown(int second)
    {
        StartCoroutine(Timer());
    }
   
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(durationDisplay);
        Endtimer();
        
    }
    void Endtimer()
    {
        gameObject.SetActive(false);
    }
    

}
