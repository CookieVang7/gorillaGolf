using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EscMenu : MonoBehaviour
{

    [SerializeField] private GameObject escMenu;

    [SerializeField] private Button mainMenu;
    [SerializeField] private Button restart;
    [SerializeField] private Button controls;
    [SerializeField] private Button closeMenu;

    [SerializeField] private Button closeControls;



    [SerializeField] private GameObject confirmRestart;
    [SerializeField] private Button yesRestart;
    [SerializeField] private Button noRestart;

    [SerializeField] private GameObject controlsScreen;

    [SerializeField] private GameObject confirmMainMenu;
    [SerializeField] private Button yesMainMenu;
    [SerializeField] private Button noMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        closeMenu.onClick.AddListener( //closes the menu
            () =>
            {
                escMenu.SetActive(false);
            });

        mainMenu.onClick.AddListener( //want to go to main menu?
            () => {
                confirmMainMenu.SetActive(true);
            });

        yesMainMenu.onClick.AddListener(
            () =>
            {
                LoadingScreen.LoadScene("MainMenu");
            });
        noMainMenu.onClick.AddListener(
            () =>
            {
                confirmMainMenu.SetActive(false);
            });

        restart.onClick.AddListener( //want to restart level?
            () => {
                confirmRestart.SetActive(true);
            });

        yesRestart.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        noRestart.onClick.AddListener(
            () =>
            {
                confirmRestart.SetActive(false);
            });


        controls.onClick.AddListener( //see controls
            () => {
                controlsScreen.SetActive(true);
            });

        closeControls.onClick.AddListener( //close controls
            () => {
                controlsScreen.SetActive(false);
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
