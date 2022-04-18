using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static int numberOfMusic;
    public static bool firstTimeLevel1;
    public static bool firstTimeLevel4;
    public static bool firstTimeLevel7;
    [SerializeField] public AudioClip[] soundtrack;
    // Start is called before the first frame update
    void Awake()
    {
        resetLevelBool();
        numberOfMusic++;
        DontDestroyOnLoad(this.gameObject);       
    }

    public void playTrack(int n) {
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.clip = soundtrack[n];
        audio.Play();
    }

    public static void resetLevelBool()
    {
        firstTimeLevel1 = false;
        firstTimeLevel4 = false;
        firstTimeLevel7 = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Application.loadedLevelName);
        // AudioSource audio = this.GetComponent<AudioSource>();
        // if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu")) {
        //      audio.clip = soundtrack[0];
        //      audio.Play();
        //  } else {
        //     audio.clip = soundtrack[1];
        //      audio.Play();
        //  }
        
    }
}
