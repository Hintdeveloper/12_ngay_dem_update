using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    public int duration;

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
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(duration);
        EndTimer();
    }

    void EndTimer()
    {
        gameObject.SetActive(false);
    }
}
