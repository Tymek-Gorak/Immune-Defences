using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = EventManager.eventManagerIns.days.ToString();
    }
}
