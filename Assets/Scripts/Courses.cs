using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Courses : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button hole1;
    [SerializeField] private Button hole2;
    [SerializeField] private Button hole3;
    [SerializeField] private Button hole4;
    [SerializeField] private Button hole5;
    [SerializeField] private Button hole6;
    [SerializeField] private Button hole7;
    [SerializeField] private Button hole8;
    [SerializeField] private Button hole9;

    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("MainMenu");
            });

        hole1.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("TutorialLevel");
            });

        hole2.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("JungleLevel2");
            });

        hole3.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("JungleLevel3");
            });

        hole4.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("SandLevel1");
            });

        hole5.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("SandLevel2");
            });

        hole6.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("SandLevel3");
            });

        hole7.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("SnowLevel1");
            });

        hole8.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("SnowLevel2");
            });

        hole9.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("JoshSnow");
            });

    }
}
