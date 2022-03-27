using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Button nextLevel;
    [SerializeField] private Button replay;


     void Start()
    {
        nextLevel.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        replay.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));



    }
}
