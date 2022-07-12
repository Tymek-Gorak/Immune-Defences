using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BodyPart : MonoBehaviour
{
    private int nameNumber;
    public float health = 100;
    public bool isAlive = true;


    void Start()
    {
        nameNumber = int.Parse(gameObject.name.Remove(0, 4)); 
        StartCoroutine("boogie");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            isAlive = false;
        }
        transform.GetChild(4).GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.01f + 1 - health / 100.0f);
    }

    void OnMouseDown() {
        foreach(GameObject part in BodyValues.bodyParts){
            if(part.GetComponent<Infection>() != null) part.GetComponent<Infection>().isSelected = false;
        }
        
        BodyPartText.BodyTextInstance.text = BodyValues.partNames[nameNumber];
        if(transform.GetComponent<Infection>() == null) {
            VirusAmountSlider.VirusSliderIns.value = 0;
            VirusAmountText.virusAmountTextInstance.text = "ilość wirusów: " + 0;
            if(!transform.GetComponent<BodyPart>().isAlive){
                VirusAmountText.virusAmountTextInstance.text = "BRAK SYGNAŁU";
            }
            VirusDeathSlider.sliderDeathIns.value = 100 - health;
        }
    }

    private IEnumerator boogie(){
        while (true){
            transform.localScale += new Vector3(0, 0, 1f);
            yield return new WaitForSeconds(0.1f);
            transform.localScale -= new Vector3(0, 0, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
