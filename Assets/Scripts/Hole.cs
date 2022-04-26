using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    [SerializeField] private Transform holeBottom;
    [SerializeField] private GameObject winScreen;
    public static WaitForSeconds waitTime = new WaitForSeconds(0.5f);


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(activateWinScreen());
        }
    }

    private IEnumerator activateWinScreen() { 
        yield return waitTime;
        winScreen.SetActive(true);
    }
}
