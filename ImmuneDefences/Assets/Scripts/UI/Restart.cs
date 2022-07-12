using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    public void restartScene(){
        SoundManager.soundInstance.Play("buttonClick");
        SceneManager.LoadScene("SampleScene");
    }
}
