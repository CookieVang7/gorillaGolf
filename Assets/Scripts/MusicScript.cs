using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static int numberOfMusic;
    private static bool firtimeJungle;
    private static bool firstTimeSand;
    private static bool firstTimeSnow;
    private static bool firstTimeChallenge;
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
        firtimeJungle = false;
        firstTimeSand = false;
        firstTimeSnow = false;
        firstTimeChallenge = false;
    }

    public static void setMusic() 
    {
        string nameOfScene = SceneManager.GetActiveScene().name;

        if (nameOfScene == "MainMenu"){
            GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(0);
            resetLevelBool();
        }
        if ((nameOfScene == "JungleLevel2" || nameOfScene == "JungleLevel3") && !MusicScript.firtimeJungle)
        {
            GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(1);
            MusicScript.firtimeJungle = true;
        }

        if ((nameOfScene == "SandLevel1" || nameOfScene == "SandLevel2" || nameOfScene == "SandLevel3") && !MusicScript.firstTimeSand)
        {
            GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(2);
            MusicScript.firstTimeSand = true;
        }

        if ((nameOfScene == "SnowLevel1" || nameOfScene == "SnowLevel2" || nameOfScene == "JoshSnow") && !MusicScript.firstTimeSnow)
        {
            GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(3);
            MusicScript.firstTimeSnow = true;
        }


        if ((nameOfScene == "BenChallenge" || nameOfScene == "JoshChallenge" || nameOfScene == "LavaChallenge") && !MusicScript.firstTimeChallenge)
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
