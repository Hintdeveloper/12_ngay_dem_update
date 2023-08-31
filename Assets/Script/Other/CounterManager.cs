using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    public static CounterManager Instance;

    //Set up counter
    public TMP_Text A6Counter;
    public TMP_Text B52Counter;
    public TMP_Text F4Counter;

    int A6currentCount = 0;
    int B52currentCount = 0;
    int F4currentCount = 0;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        A6Counter.text = A6currentCount.ToString();
        B52Counter.text = B52currentCount.ToString();
        F4Counter.text = F4currentCount.ToString();
    }

    public void IncreaseA6()
    {
        A6currentCount++;
        A6Counter.text = A6currentCount.ToString();
    }
    public void IncreaseB52()
    {
        B52currentCount++;
        B52Counter.text = B52currentCount.ToString();
    }
    public void IncreaseF4()
    {
        F4currentCount++;
        F4Counter.text = F4currentCount.ToString();
    }
}
