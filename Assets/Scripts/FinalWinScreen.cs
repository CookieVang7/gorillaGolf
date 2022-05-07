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
    public TMP_InputField userNameInput;
    public PlayfabManager playfabManager;
    public GameObject timeLeaderBoards;

    public string username;

    void Start()
    {
        Counter.isMenuOpen = true;
        GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(0);
        Time.timeScale = 0;
        nextLevel.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            LoadingScreen.LoadScene(nextScene.Name());
            Counter.isMenuOpen = false;
        });
     
        replay.onClick.AddListener(() => {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameObject.Find("Music(Clone)").GetComponent<MusicScript>().resetLevelBool();
            Counter.isMenuOpen = false;
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


    ///<summary>
    /// Submit completion time to leaderboards (currently just works for challenge courses)
    ///</summary>
    public void SubmitTime()
    {
        username = userNameInput.text;
        playfabManager.UpdateUserTitleDisplayNameRequest(username);
        playfabManager.SendLeaderboardTime((int)Counter.currentTime);
        userNameInput.gameObject.SetActive(false);
        StartCoroutine(WaitThenDisplayTimes());
        // open leaderboards
    }


    ///<summary>
    /// Delay showing leaderboard times for a bit so we can get updates from the server.
    /// \n Not super elegant but it should work unless the server is dying.
    /// </summary>
    public IEnumerator WaitThenDisplayTimes()
    {
        yield return new WaitForSecondsRealtime(1f);
        playfabManager.GetTimeLeaderboard();
        yield return new WaitForSecondsRealtime(1f);
        timeLeaderBoards.SetActive(true);
    }
}

