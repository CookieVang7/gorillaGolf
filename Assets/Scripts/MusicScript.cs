using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    // Booleans are used to keep music from constantly starting over on death/reset
    private bool firtimeJungle;
    private bool firstTimeSand;
    private bool firstTimeSnow;
    private bool firstTimeChallenge;
    private bool firstTimeSpace;
    public bool fromCourseMenu; //Keeps the music from replaying when going from courses -> mainMenu
    public AudioSource audioSource;
    [SerializeField] public AudioClip[] soundtrack;
    void Awake()
    {
        resetLevelBool();
        Counter.numberOfMusic++;
        audioSource = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);       
    }

    public void playTrack(int n) {
        audioSource.clip = soundtrack[n];
        audioSource.Play();
    }

    public void resetLevelBool()
    {
        firtimeJungle = false;
        firstTimeSand = false;
        firstTimeSnow = false;
        firstTimeSpace = false;
        firstTimeChallenge = false;
        fromCourseMenu = false;
    }

    public void setMusic() 
    {
        string nameOfScene = SceneManager.GetActiveScene().name;
        MusicScript musicPlayer = GameObject.Find("Music(Clone)").GetComponent<MusicScript>();

        if (nameOfScene == "Courses"){
            fromCourseMenu = true;
        }

        if (nameOfScene == "MainMenu" && !fromCourseMenu){
            musicPlayer.playTrack(0);
            resetLevelBool();
        }
        if ((nameOfScene == "TutorialLevel" || nameOfScene == "JungleLevel2" || nameOfScene == "JungleLevel3") && !firtimeJungle)
        {
            musicPlayer.playTrack(1);
            firtimeJungle = true;
            fromCourseMenu = false;
        }

        if ((nameOfScene == "SandLevel1" || nameOfScene == "SandLevel2" || nameOfScene == "SandLevel3") && !firstTimeSand)
        {
            musicPlayer.playTrack(2);
            firstTimeSand = true;
            fromCourseMenu = false;
        }

        if ((nameOfScene == "SnowLevel1" || nameOfScene == "SnowLevel2" || nameOfScene == "JoshSnow") && !firstTimeSnow)
        {
            musicPlayer.playTrack(3);
            firstTimeSnow = true;
            fromCourseMenu = false;
        }


        if ((nameOfScene == "SpaceLevel1" || nameOfScene == "SpaceLevel2" || nameOfScene == "SpaceLevel3") && !firstTimeSpace)
        {
            musicPlayer.playTrack(4);
            firstTimeSpace = true;
            fromCourseMenu = false;
        }

        if ((nameOfScene == "BenChallenge" || nameOfScene == "JoshChallenge" || nameOfScene == "LavaChallenge") && !firstTimeChallenge)
        {
            musicPlayer.playTrack(5);
            firstTimeChallenge = true;
            fromCourseMenu = false;
        }
    }
}
