using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button openCredits;
    [SerializeField] private Button closeCredits;
    [SerializeField] private GameObject creditsUI;

    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("TutorialLevel");
            });

        openCredits.onClick.AddListener(
            () => {
                creditsUI.SetActive(true);
            });

        closeCredits.onClick.AddListener(
            () => {
                creditsUI.SetActive(false);
            });
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
