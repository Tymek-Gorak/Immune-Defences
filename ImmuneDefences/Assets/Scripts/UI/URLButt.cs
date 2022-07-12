using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLButt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenURL(){
        string i = "//www.youtube.com/watch?v=lXfEK8G8CUI&t=563s/";
        SoundManager.soundInstance.Play("buttonClick");
        Application.OpenURL(i);
    }
}
