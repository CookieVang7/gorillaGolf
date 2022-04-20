using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private static GameObject timerInstance;
    public static float currentTime = 0;
    public static int seconds;
    public static int minutes;
    public static int hours;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (timerInstance == null)
        {
            timerInstance = gameObject;
        }
        else
            Destroy(gameObject);
    }
    

}