using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalWinScreen : MonoBehaviour
{
    [SerializeField] private Button nextLevel;
    [SerializeField] private Button replay;
    [SerializeField] private Scenes nextScene;
    [SerializeField] private TMP_Text par;
    [SerializeField] private TMP_Text strokes;
    [SerializeField] private TMP_Text deaths;
    [SerializeField] private TMP_Text completedStrokes;
    [SerializeField] private TMP_Text incompleteStokes;
    [SerializeField] private TMP_Text score;
    [SerializeField] private GameUI gameUI;
    void Start()
    {
        DeathCounter.totalCompletedStrokes = DeathCounter.totalCompletedStrokes + DragNShoot.hitCount;
        nextLevel.onClick.AddListener(() => LoadingScreen.LoadScene(nextScene.Name()));
        replay.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        strokes.text = "Strokes: " + DragNShoot.hitCount;
        deaths.text = "Deaths: " + DeathCounter.deathCount;
        par.text = "Par: " + gameUI.getPar();
        int score = DragNShoot.hitCount - gameUI.getPar();
        if(score > 0) {
             this.score.text = "Score: +" + score;
        }
        else {
            this.score.text = "Score: " + score;
        }
        completedStrokes.text = "Total Completed Strokes: " + DeathCounter.totalCompletedStrokes;
        incompleteStokes.text = "Total Strokes: " + DeathCounter.totalDeathStrokes;
    }
}

