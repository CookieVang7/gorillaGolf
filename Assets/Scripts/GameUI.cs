using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text hitCountText;
    public static int strokes = 0;

    // Start is called before the first frame update
    public void UpdateHitCount(int count)
    {
        hitCountText.text = "Strokes: " + count;
        strokes++;
    }
}
