using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonTutorialMenu : MonoBehaviour
{
    [SerializeField] private GameObject tutorialMenu;
    [SerializeField] private bool alreadyAccessed;
    [SerializeField] private GameObject wall;
    // Start is called before the first frame update
    private void Start()
    {
        alreadyAccessed = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gorilla") && !alreadyAccessed)
        {
            tutorialMenu.SetActive(true);
            alreadyAccessed = true;
        }
        if (wall != null && collision.gameObject.CompareTag("Gorilla"))
        {
            wall.SetActive(true);
        }
    }
}
