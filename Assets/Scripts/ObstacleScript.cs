using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    //[SerializeField] private DeathCounter deathCounter;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathCounter.IncrementDeathCount();

        if (collision.gameObject.CompareTag("Gorilla"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        if (collision.gameObject.tag == "Ball")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
