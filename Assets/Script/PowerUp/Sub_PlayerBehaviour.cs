using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_PlayerBehaviour : MonoBehaviour
{
    public int duration;

    int remainingDuration;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CoolDown(duration);
    }
    void CoolDown(int second)
    {
        remainingDuration = second;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (remainingDuration >= 0)
        {
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        EndTimer();
    }

    void EndTimer()
    {
        gameObject.SetActive(false);
    }

}
