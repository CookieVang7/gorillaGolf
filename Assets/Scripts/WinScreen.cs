using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Button nextLevel;
    [SerializeField] private Button replay;
    [SerializeField] private Scenes nextScene;
    [SerializeField] private TMP_Text strokes;
    [SerializeField] private TMP_Text par;
    [SerializeField] private TMP_Text score;
    [SerializeField] private GameUI gameUI;
    void Start()
    {
        nextLevel.onClick.AddListener(() => LoadingScreen.LoadScene(nextScene.Name()));
        replay.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        strokes.text = "Strokes: " + DragNShoot.hitCount;
        par.text = "Par: " + gameUI.getPar();
        int score = DragNShoot.hitCount - gameUI.getPar();
        if(score > 0) {
             this.score.text = "Score: +" + score;
        }
        else {
            this.score.text = "Score: " + score;
        }
        DeathCounter.totalCompletedStrokes = DeathCounter.totalCompletedStrokes + DragNShoot.hitCount;
        Debug.Log("Total Used Strokes: " + DeathCounter.totalCompletedStrokes);
        Debug.Log("Total Strokes Overall: " + DeathCounter.totalDeathStrokes);
    }

}
