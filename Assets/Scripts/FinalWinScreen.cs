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
    public GameObject rowParent; // vertical layout group for score rows

    public string username;
    public static readonly string challengeLeaderboardName = "Best Challenge Course Times";
    public static readonly string casualLeaderboardName = "Best Casual Course Times";

    void Awake()
    {
        playfabManager = GameObject.Find("PlayfabManager").GetComponent<PlayfabManager>();
    }

    void Start()
    {
        playfabManager.rowsParent = rowParent.transform;
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
    /// leaderboardName refers to the specific leaderboard (currently Best Casual Course Times and Best Challenge Course Times)
    /// stored within Playfab
    ///</summary>
    public void SubmitTime()
    {
        string leaderboardName;
        if (SceneManager.GetActiveScene().name == "SpaceLevel3") // assumes a pretty static state of our levels that should be fine since we probably won't be making more
        {
            leaderboardName = challengeLeaderboardName;
        }
        else leaderboardName = casualLeaderboardName; 

        username = userNameInput.text;
        playfabManager.UpdateUserTitleDisplayNameRequest(username);
        playfabManager.SendLeaderboardTime((int)Counter.currentTime, leaderboardName);
        userNameInput.gameObject.SetActive(false);
        StartCoroutine(WaitThenDisplayTimes(leaderboardName));
    }


    ///<summary>
    /// Delay showing leaderboard times for a bit so we can get updates from the server.
    /// Not super elegant but it should work unless the server is dying.
    /// </summary>
    public IEnumerator WaitThenDisplayTimes(string leaderboardName)
    {
        yield return new WaitForSecondsRealtime(1f);
        playfabManager.GetTimeLeaderboard(leaderboardName);
        yield return new WaitForSecondsRealtime(1f);
        timeLeaderBoards.SetActive(true);
    }

    public void CloseLeaderboards()
    {
        timeLeaderBoards.SetActive(false);
    }
}

