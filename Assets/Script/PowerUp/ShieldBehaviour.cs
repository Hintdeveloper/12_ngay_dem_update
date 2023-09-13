using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
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
        ShieldCoolDown(duration);
    }

    public void ShieldCoolDown(int second)
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
