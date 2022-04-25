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
    [SerializeField] private TMP_Text score;
    [SerializeField] private GameUI gameUI;
    void Start()
    {
        GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(0);
        Time.timeScale = 0;
        nextLevel.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            LoadingScreen.LoadScene(nextScene.Name());
        });
     
        replay.onClick.AddListener(() => {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });

        strokes.text = "Strokes: " + Counter.hitCount;
        deaths.text = "Deaths: " + Counter.deathCount;
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

