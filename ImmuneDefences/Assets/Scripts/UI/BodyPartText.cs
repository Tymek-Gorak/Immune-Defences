using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BodyPartText : MonoBehaviour
{
    
    private static TextMeshProUGUI bodyText;
    public static TextMeshProUGUI BodyTextInstance { 
        get{
            if(bodyText == null) bodyText = GameObject.Find("UI").transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            return bodyText;
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
