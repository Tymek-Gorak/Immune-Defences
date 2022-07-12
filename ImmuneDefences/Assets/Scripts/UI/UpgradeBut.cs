using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeBut : MonoBehaviour
{
    [SerializeField] private int bacNum;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private TextMeshProUGUI CostCostText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private string title;
    [SerializeField] private string desc;
    [SerializeField] private int price;
    [SerializeField] private float strengthMod;
    [SerializeField] private int durationMod;
    [SerializeField] private int randomTimeMod;
    [SerializeField] private int priceMod;
    [SerializeField] private GameObject nextBut;
    [SerializeField] private List<GameObject> antibodies = new List<GameObject>();
    [SerializeField] private int antibodyValue;

    public Color startColor;
    private float clicktime = 0;
    private float clickdelay = 0.5f;
    private float clicks = 0;
    public bool isBought = false;

    void Start()
    {
        startColor = transform.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBought){
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<UpgradeBut>().startColor.r * 1/3, gameObject.GetComponent<UpgradeBut>().startColor.g * 1/3, gameObject.GetComponent<UpgradeBut>().startColor.b * 1/3);
        }
    }

    public void clicked(){
        titleText.text = title;
        descText.text = desc;
        CostCostText.text = "Cena: ";
        priceText.text = price.ToString();
        SoundManager.soundInstance.Play("buttonClick");
        clicks++;
        if (clicks == 1) clicktime = Time.time;

        if (clicks > 1 && Time.time - clicktime < clickdelay)
        {
            clicks = 0;
            clicktime = 0;
            if (EventManager.eventManagerIns.money >= price && !isBought && antibodyValue != BodyValues.bacs[4].transform.GetComponent<BCell>().antibody){
                EventManager.eventManagerIns.money -= price;
                isBought = true;
                SoundManager.soundInstance.Play("buy");
                if(antibodyValue == 0){
                    BodyValues.bacs[bacNum].multiplier += strengthMod;
                    BodyValues.bacs[bacNum].longevity += durationMod;
                    BodyValues.bacs[bacNum].randomLife -= randomTimeMod;
                    BodyValues.bacs[bacNum].price -= priceMod;
                    if(nextBut != null) nextBut.SetActive(true);
                }
                else{
                    foreach(GameObject g in antibodies){
                        g.GetComponent<Image>().color = new Color( g.GetComponent<UpgradeBut>().startColor.r * 1/3, g.GetComponent<UpgradeBut>().startColor.g * 1/3, g.GetComponent<UpgradeBut>().startColor.b * 1/3);
                        GameObject.Find("bCell").transform.GetComponent<BCell>().antibody = antibodyValue;
                        isBought = false;
                    }
                    BodyValues.bacs[bacNum].transform.GetComponent<BCell>().antibody = antibodyValue;
                    transform.GetComponent<Image>().color = startColor;
                }
            }
            else{
                SoundManager.soundInstance.Play("buyFail");
            }

        }
        else if (clicks > 2 || Time.time - clicktime > 1) clicks = 0;
    
    
    }
}
