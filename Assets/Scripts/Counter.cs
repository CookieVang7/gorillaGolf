using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public static float currentTime = 0;
    public static int seconds;
    public static int minutes;
    public static int hours;
    public static float deathCount = 0;
    public static int hitCount;
    public static int numberOfMusic;
    public static bool isMenuOpen;

    public static void resetCounter() {
        currentTime = 0;
        seconds = 0;
        minutes = 0;
        hours = 0;
        deathCount = 0;
        hitCount = 0;
        isMenuOpen = false;
    }
}