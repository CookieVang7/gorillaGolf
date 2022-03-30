using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Button nextLevel;
    [SerializeField] private Button replay;
    [SerializeField] private Scenes nextScene;
    [SerializeField] private TMP_Text strokes;

    void Start()
    {
        nextLevel.onClick.AddListener(() => LoadingScreen.LoadScene(nextScene.Name()));
        replay.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        strokes.text = "Strokes: " + DragNShoot.hitCount;
    }

    public static void updateStrokesOnWinScreen()
    {

    }

    

}
