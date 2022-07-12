using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusDeathSlider : MonoBehaviour
{
    private static Slider SliderDeath;
    public static Slider sliderDeathIns { 
        get{
            if(SliderDeath == null) SliderDeath = GameObject.Find("UI").transform.GetChild(0).GetChild(2).GetComponent<Slider>();
            return SliderDeath;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
