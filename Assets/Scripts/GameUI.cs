using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text hitCountText;
    [SerializeField] private TMP_Text deathCountText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text parText;
    [SerializeField] private int par;
    // Start is called before the first frame update
    private void Start()
    {
        deathCountText.text = "Deaths: " + Counter.deathCount;
        parText.text = "Par: " + par;

    }
    public void UpdateHitCount(int count)
    {
        hitCountText.text = "Strokes: " + count;
        
    }
    public void UpdateDeathCount()
    {
        deathCountText.text = "Deaths: " + Counter.deathCount;
    }

    private void Update()
    {
        Counter.currentTime += Time.deltaTime;
        Counter.seconds = (int)(Counter.currentTime % 60);
        Counter.minutes = (int)(Counter.currentTime / 60) % 60;
        Counter.hours = (int)(Counter.currentTime / 3600) % 24;
        string formattedTime = string.Format("{0:0}:{1:00}:{2:00}", Counter.hours, Counter.minutes, Counter.seconds);
        timerText.text = formattedTime;
    }

    public int getPar() {
        return par;
    }

}
