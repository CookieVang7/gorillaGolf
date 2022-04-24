using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text hitCountText;
    [SerializeField] private TMP_Text deathCountText;
    [SerializeField] private TMP_Text timerText;
    // Start is called before the first frame update
    private void Start()
    {
        deathCountText.text = "Deaths: " + DeathCounter.deathCount;
    }
    public void UpdateHitCount(int count)
    {
        hitCountText.text = "Strokes: " + count;
        
    }
    public void UpdateDeathCount()
    {
        Debug.Log(deathCountText.text);
        deathCountText.text = "Deaths: " + DeathCounter.deathCount;
    }

    private void Update()
    {
        Timer.currentTime += Time.deltaTime;
        Timer.seconds = (int)(Timer.currentTime % 60);
        Timer.minutes = (int)(Timer.currentTime / 60) % 60;
        Timer.hours = (int)(Timer.currentTime / 3600) % 24;
        string formattedTime = string.Format("{0:0}:{1:00}:{2:00}", Timer.hours, Timer.minutes, Timer.seconds);
        timerText.text = formattedTime;
    }

}
