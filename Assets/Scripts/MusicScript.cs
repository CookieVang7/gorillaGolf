using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static int numberOfMusic;
    // Start is called before the first frame update
    void Awake()
    {
            numberOfMusic++;
            DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
