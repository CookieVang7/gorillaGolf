using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private static GameObject timerInstance;
    public static float currentTime = 0;

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
    public static void IncrementDeathCount()
    {
        currentTime += (int)Time.deltaTime;
    }

}