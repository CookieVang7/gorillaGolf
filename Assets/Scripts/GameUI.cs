using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text hitCountText;
    [SerializeField] private TMP_Text deathCountText;
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

}
