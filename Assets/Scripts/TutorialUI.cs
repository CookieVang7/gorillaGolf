using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private GameObject tutorialMenu;
    [SerializeField] private Button closeMenu;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
        Counter.isMenuOpen = true;
    }
    void Start()
    {
        closeMenu.onClick.AddListener( //closes the menu
    () =>
    {
        Time.timeScale = 1;
        tutorialMenu.SetActive(false);
        Counter.isMenuOpen = false;
    });

    }
}
