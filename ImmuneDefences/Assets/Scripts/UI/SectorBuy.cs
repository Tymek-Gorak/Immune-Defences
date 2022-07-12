using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorBuy : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private GameObject buttonSmall;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void purchase(){
        SoundManager.soundInstance.Play("buttonClick");
        if(EventManager.eventManagerIns.money >= price){
            SoundManager.soundInstance.Play("buy");
            EventManager.eventManagerIns.money -= price;
            buttonSmall.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
        else{
            SoundManager.soundInstance.Play("buyFail");
        }
    }
}
