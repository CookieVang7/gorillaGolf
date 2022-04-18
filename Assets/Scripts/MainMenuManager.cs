using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button courses;
    [SerializeField] private Button openCredits;
    [SerializeField] private Button closeCredits;
    [SerializeField] private GameObject creditsUI;
    [SerializeField] private GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        MusicScript.resetLevelBool();
        DeathCounter.deathCount = 0;
        DeathCounter.totalCompletedStrokes = 0;
        DeathCounter.totalDeathStrokes = 0;
        startGame.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("TutorialLevel");
            });

        courses.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("Courses");
            });

        openCredits.onClick.AddListener(
            () => {
                creditsUI.SetActive(true);
            });

        closeCredits.onClick.AddListener(
            () => {
                creditsUI.SetActive(false);
            });
            
        if(MusicScript.numberOfMusic < 1)
        {
            Object.Instantiate(music).GetComponent<MusicScript>().playTrack(0);;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
