using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    private Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();

    private static SoundManager soundManager;
    public  static SoundManager soundInstance { 
        get { 
            if(soundManager == null) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            return soundManager; 

    } }


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        sounds.Add("buttonClick", (AudioClip) Resources.Load("Sounds/Button"));
        sounds.Add("buy", (AudioClip) Resources.Load("Sounds/PassBuy"));
        sounds.Add("buyFail", (AudioClip) Resources.Load("Sounds/FailBuy"));
        sounds.Add("lose", (AudioClip) Resources.Load("Sounds/lose"));
        sounds.Add("win", (AudioClip) Resources.Load("Sounds/win"));
        sounds.Add("selectUnit", (AudioClip) Resources.Load("Sounds/selectUnit"));
        sounds.Add("denSuc", (AudioClip) Resources.Load("Sounds/DendriSucess"));
        sounds.Add("zoneClear", (AudioClip) Resources.Load("Sounds/Clear_body_part"));
    }

    public void Play(string soundName){
        source.PlayOneShot(sounds[soundName]);
    }
}
