using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    [SerializeField] private Transform holeBottom;
    public static WaitForSeconds waitTime = new WaitForSeconds(1f);


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(nextLevel());
        }
    }

    private IEnumerator nextLevel() { 
        yield return waitTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
