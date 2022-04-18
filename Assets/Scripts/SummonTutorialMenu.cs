using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonTutorialMenu : MonoBehaviour
{
    [SerializeField] private GameObject tutorialMenu;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gorilla"))
        {
            tutorialMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
