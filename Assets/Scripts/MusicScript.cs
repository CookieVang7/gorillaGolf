using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static int numberOfMusic;
    private bool firtimeJungle;
    private bool firstTimeSand;
    private bool firstTimeSnow;
    private bool firstTimeChallenge;
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

    public void resetLevelBool()
    {
        firtimeJungle = false;
        firstTimeSand = false;
        firstTimeSnow = false;
        firstTimeChallenge = false;
    }

    public void setMusic() 
    {
        string nameOfScene = SceneManager.GetActiveScene().name;
        MusicScript musicPlayer = GameObject.Find("Music(Clone)").GetComponent<MusicScript>();

        if (nameOfScene == "MainMenu"){
            musicPlayer.playTrack(0);
            resetLevelBool();
        }
        if ((nameOfScene == "TutorialLevel" || nameOfScene == "JungleLevel2" || nameOfScene == "JungleLevel3") && !this.firtimeJungle)
        {
            musicPlayer.playTrack(1);
            this.firtimeJungle = true;
        }

        if ((nameOfScene == "SandLevel1" || nameOfScene == "SandLevel2" || nameOfScene == "SandLevel3") && !this.firstTimeSand)
        {
            musicPlayer.playTrack(2);
            this.firstTimeSand = true;
        }

        if ((nameOfScene == "SnowLevel1" || nameOfScene == "SnowLevel2" || nameOfScene == "JoshSnow") && !this.firstTimeSnow)
        {
            musicPlayer.playTrack(3);
            this.firstTimeSnow = true;
        }


        if ((nameOfScene == "SpaceLevel1" || nameOfScene == "SpaceLevel2" || nameOfScene == "SpaceLevel3") && !this.firstTimeChallenge)
        {
            musicPlayer.playTrack(4);
            this.firstTimeChallenge = true;
        }

        if ((nameOfScene == "BenChallenge" || nameOfScene == "JoshChallenge" || nameOfScene == "LavaChallenge") && !this.firstTimeChallenge)
        {
            musicPlayer.playTrack(5);
            this.firstTimeChallenge = true;
        }
    }
}
