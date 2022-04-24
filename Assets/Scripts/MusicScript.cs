using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static int numberOfMusic;
    public static bool firstTimeLevel2;
    public static bool firstTimeLevel4;
    public static bool firstTimeLevel7;
    public static bool firstTimeChallenge;
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
        firstTimeLevel2 = false;
        firstTimeLevel4 = false;
        firstTimeLevel7 = false;
        firstTimeChallenge = false;
    }

    public static void setMusic() 
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TutorialLeve2") && !MusicScript.firstTimeLevel2)
        {
            GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(1);
            MusicScript.firstTimeLevel2 = true;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SandLevel1") && !MusicScript.firstTimeLevel4)
        {
            GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(2);
            MusicScript.firstTimeLevel4 = true;
        }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BenChallenge") && !MusicScript.firstTimeChallenge)
        {
            GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(5);
            MusicScript.firstTimeChallenge = true;
        }
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
