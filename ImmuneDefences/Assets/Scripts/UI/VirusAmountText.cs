using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VirusAmountText : MonoBehaviour
{
    // Start is called before the first frame update
    
    private static TextMeshProUGUI virusText;
    public static TextMeshProUGUI virusAmountTextInstance { 
        get{
            if(virusText == null) virusText = GameObject.Find("UI").transform.GetChild(0).GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
            return virusText;
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
