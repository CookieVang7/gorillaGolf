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
        Time.timeScale = 0;
        nextLevel.onClick.AddListener(() => {

            LoadingScreen.LoadScene(nextScene.Name());
            Time.timeScale = 1;

        });
        replay.onClick.AddListener(() => {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });

        strokes.text = "Strokes: " + Counter.hitCount;
        par.text = "Par: " + gameUI.getPar();
        int score = Counter.hitCount - gameUI.getPar();
        if(score > 0) {
             this.score.text = "Score: +" + score;
        }
        else {
            this.score.text = "Score: " + score;
        }
    }

}
