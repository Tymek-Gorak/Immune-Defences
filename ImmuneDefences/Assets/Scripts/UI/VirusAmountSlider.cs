using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusAmountSlider : MonoBehaviour
{
    
    private static Slider virusSlider;
    public static Slider VirusSliderIns { 
        get{
            if(virusSlider == null) virusSlider = GameObject.Find("UI").transform.GetChild(0).GetComponentInChildren<Slider>();
            return virusSlider;
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
