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

    [SerializeField] private GameObject controlsScreen;

    [SerializeField] private GameObject confirmMainMenu;
    [SerializeField] private Button yesMainMenu;
    [SerializeField] private Button noMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        Counter.isMenuOpen = true;
        closeMenu.onClick.AddListener( //closes the menu
            () =>
            {
                Time.timeScale = 1;
                escMenu.SetActive(false);
                Counter.isMenuOpen = false;
            });

        mainMenu.onClick.AddListener( //want to go to main menu?
            () => {
                confirmMainMenu.SetActive(true);
            });

        yesMainMenu.onClick.AddListener(
            () =>
            {
                Time.timeScale = 1;
                LoadingScreen.LoadScene("MainMenu");
                Counter.isMenuOpen = false;
            });
        noMainMenu.onClick.AddListener(
            () =>
            {
                confirmMainMenu.SetActive(false);
            });

        restart.onClick.AddListener( //want to restart level?
            () => {
                //confirmRestart.SetActive(true);
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Counter.isMenuOpen = false;
                Counter.deathCount++;
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
