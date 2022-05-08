using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{

    public GameObject rowPrefab;
    public Transform rowsParent;

    private static PlayfabManager playfabInstance; //check if we have more than one copy of playfabmanager
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (playfabInstance == null) // make sure we don't duplicate this when reloading scenes
        {
            playfabInstance = this;
        }
        else GameObject.Destroy(gameObject);
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest{
            CustomId = SystemInfo.deviceUniqueIdentifier,
             CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }


    void OnSuccess(LoginResult result) 
    {
        Debug.Log("account successfully created");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error creating account");
        Debug.Log(error.GenerateErrorReport());
    }

    void OnNameUpdateError(PlayFabError error)
    {
        Debug.Log("name failed to update");
        Debug.Log(error.GenerateErrorReport());
    }

    public void UpdateUserTitleDisplayNameRequest(string newName)
    {
        var request = new UpdateUserTitleDisplayNameRequest {
            DisplayName = newName
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnUserDisplayNameUpdate, OnNameUpdateError);
    }


    public void SendLeaderboardTime(int time)
    {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "Best Challenge Course Times",
                    Value = time
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    public void GetTimeLeaderboard()
    {
        var request = new GetLeaderboardRequest {
            StatisticName = "Best Challenge Course Times",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }

    void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard) {
            if (item != null)
            {
                GameObject rowGO = Instantiate(rowPrefab, rowsParent);
                TMP_Text[] rowInfo = rowGO.GetComponentsInChildren<TMP_Text>();
                rowInfo[0].text = item.Position.ToString();
                rowInfo[1].text = item.DisplayName;
                rowInfo[2].text = FormatLeaderboardTime(item.StatValue); // convert score time from int to formatted time
            }
        }
    }


    ///<summary>
    /// Takes time in seconds and formats it as hours:minutes:seconds
    ///</summary>
    string FormatLeaderboardTime(int time)
    {
        int seconds = (int)(time % 60);
        int minutes = (int)(time / 60) % 60;
        int hours = (int)(time / 3600) % 24;
        return string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leaderboard sent");
    }

    void OnUserDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("user name successfully updated");
    }
}
