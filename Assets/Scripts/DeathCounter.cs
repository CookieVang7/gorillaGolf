using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    private static GameObject instance;
    public static float totalDeathStrokes = 0;
    public static float totalCompletedStrokes = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = gameObject;
        }
        else
            Destroy(gameObject);
    }
    // Maybe delete the extra counters
}
