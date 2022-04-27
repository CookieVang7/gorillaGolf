using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeCourses : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button hole1;
    [SerializeField] private Button hole2;
    [SerializeField] private Button hole3;
    [SerializeField] private Button hole4;
    [SerializeField] private Button hole5;
    [SerializeField] private Button hole6;

    // Start is called before the first frame update
    void Start()
    {
        
        backButton.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("Courses");
            });

        hole1.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("BenChallenge");
            });

        hole2.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("LavaChallenge");
            });

        hole3.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("JoshChallenge");
            });

        hole4.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("SpaceLevel1");
            });

        hole5.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("SpaceLevel2");
            });

        hole6.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("SpaceLevel3");
            });

        GameObject.Find("Music(Clone)").GetComponent<MusicScript>().setMusic();

    }
}

