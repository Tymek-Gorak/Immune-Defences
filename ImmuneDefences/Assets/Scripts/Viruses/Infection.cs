using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class Infection : MonoBehaviour
{
    //INFECTION THINGY THANGIES
    
    private bool infected = false;
    private float tick = 1.0f;
    private float time = 0f;
    private float multiplier = 0f;
    private int currentViruses = 0;
    private int maxSprites = 140;
    public int maxViruses;
    private float a;
    private float b;    
    public int spreadLimit = 2000;
    [SerializeField] private int spreadLock = 0;
    [SerializeField] public float spreadSpeed = 1;
    public bool isSelected = false; 
    public GameObject virus; 
    public float viruses = 1;
    private List<GameObject> spritesLive = new List<GameObject>();
    private bool isSpawningSp = false;
    private int points;
    public int virusNum = 1;
    public float damage = 1; 
    private float bacMultiplier = 0;
    private bool isSpreading = false;

    //BACS AND DEFENSE RELATED THINGS
    
    private int antibody = 0; 
    public List<int> currBacs = new List<int>();
    [SerializeField] private bool isCured = false;
    public List<Bac> bacs = new List<Bac>();
    private int bacAttackerNum;
    private int nameNumber;


    void Start()
    {
        bacs.Add(GameObject.Find("macrophage").GetComponent<Bac>());
        bacs.Add(GameObject.Find("kamikaze").GetComponent<Bac>());
        bacs.Add(GameObject.Find("tentacle").GetComponent<Bac>());
        bacs.Add(GameObject.Find("bCell").GetComponent<Bac>());

        antibody = BodyValues.virusAntibodies[virusNum].Item1;
        damage = BodyValues.virusAntibodies[virusNum].Item2;
        virus = BodyValues.virusAntibodies[virusNum].Item3;
        multiplier = BodyValues.virusAntibodies[virusNum].Item4;
        spreadLimit = BodyValues.virusAntibodies[virusNum].Item5;
        spreadSpeed = BodyValues.virusAntibodies[virusNum].Item6;
        points = BodyValues.virusAntibodies[virusNum].Item7;


        nameNumber = int.Parse(gameObject.name.Remove(0, 4)); 
        maxViruses = BodyValues.bodyValues[nameNumber].Item1;
        maxSprites = BodyValues.bodyValues[nameNumber].Item2;
        a = BodyValues.bodyValues[nameNumber].Item3;
        b = BodyValues.bodyValues[nameNumber].Item4;
        spreadLimit = Random.Range(spreadLimit - 500, spreadLimit + 500);
        
        StartCoroutine("disease");
        StartCoroutine(removeSprite());
        GameObject bac = Instantiate(virus, new Vector3(0, 0, 0), Quaternion.identity);
        spritesLive.Add(bac);
        bac.transform.SetParent(GameObject.Find("Canvas").transform);
        bac.GetComponent<SpawnInBorder>().target = this.transform;
        currentViruses++;
        StartCoroutine(invincibility());
        StartCoroutine(cooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if(nameNumber == 1 && !transform.GetComponent<BodyPart>().isAlive){
            EventManager.eventManagerIns.lose();
        }


        time += Time.deltaTime * EventManager.timeSpeed;
        
        // TICKER
        
        if(time >= tick){
            tick += 1;
            if(infected == true && viruses <= maxViruses){
                if(viruses > maxViruses / 6 * 5 && viruses <= maxViruses && spreadLock <= 5){
                    viruses *= Random.Range(1.01f, 1.02f) + multiplier/ 6 * 2 + bacMultiplier / 3;
                    transform.GetComponent<BodyPart>().health -= damage * 1.2f;
                }
                else if(viruses > maxViruses / 6 * 4 && viruses < maxViruses / 6 * 5 && spreadLock <= 4){
                    viruses *= Random.Range(1.02f, 1.03f) + multiplier/ 6 * 4 + bacMultiplier / 2;
                    transform.GetComponent<BodyPart>().health -= damage;
                }
                else if(viruses > maxViruses / 6 * 3 && viruses < maxViruses / 6 * 4 && spreadLock <= 3){
                    viruses *= Random.Range(1.03f, 1.05f) + multiplier;
                }
                else if(viruses > maxViruses / 6 * 2 && viruses < maxViruses / 6 * 3 && spreadLock <= 2 || spreadLock == 2){
                    viruses *= Random.Range(1.06f, 1.08f) + multiplier / 6 * 6;
                    if(spreadLock - 1 == 0){
                        spreadLock = 2;
                    }
                }
                else if(viruses > maxViruses / 6 && viruses < maxViruses / 6 * 2 && spreadLock <= 1 || spreadLock == 1){
                    if(spreadLock - 1 == -1){
                        spreadLock = 1;
                    }
                    viruses *= Random.Range(1.08f, 1.1f) + multiplier / 6 * 7;
                }
                else if(viruses <= maxViruses / 6 && spreadLock <= 1 || spreadLock == 0){
                    viruses *= Random.Range(1.3f, 1.55f) + multiplier / 6 * 8;
                }
                
                viruses = Mathf.Clamp(viruses, 0, maxViruses);
            }
            if(isSelected == true){
                if(viruses > 25000000){
                    VirusAmountSlider.VirusSliderIns.value = viruses;
                }
                else{
                    VirusAmountSlider.VirusSliderIns.value = 25000000;
                }
                VirusAmountText.virusAmountTextInstance.text = "ilość wirusów: " + ((int) viruses).ToString("n", new NumberFormatInfo{NumberGroupSeparator = " "}).Remove(((int) viruses).ToString("n", new NumberFormatInfo{NumberGroupSeparator = " "}).Length - 3);
                VirusDeathSlider.sliderDeathIns.value = 100 - transform.GetComponent<BodyPart>().health;
                if(viruses < 30 && spreadLock > 0 && transform.GetComponent<BodyPart>().isAlive){
                    viruses = 0;
                    foreach(GameObject g in spritesLive){
                        Destroy(g);
                    }
                    if(isSelected) VirusAmountText.virusAmountTextInstance.text = "ilość wirusów: " + ((int) viruses).ToString("n", new NumberFormatInfo{NumberGroupSeparator = " "}).Remove(((int) viruses).ToString("n", new NumberFormatInfo{NumberGroupSeparator = " "}).Length - 3);
                    VirusAmountSlider.VirusSliderIns.value = 0;
                    foreach(int i in currBacs){
                        BodyValues.bodyParts[nameNumber - 1].transform.GetChild(i - 1).gameObject.SetActive(false);
                    }
                    EventManager.eventManagerIns.money += points;
                    SoundManager.soundInstance.Play("zoneClear");
                    Destroy(this);
                }
            }
            
            if(tick >= 3){
                infected = true;
            }
            if (viruses >= spreadLimit && isSpreading){
                float i = Random.Range(1, (int) Mathf.Round(10f * spreadSpeed) + 1);
                if(i == 1){
                    GameObject g = BodyValues.bodyValues[nameNumber].Item5[Random.Range(0, BodyValues.bodyValues[nameNumber].Item5.Count)];
                    if(g.GetComponent<Infection>() == null && g.GetComponent<BodyPart>().isAlive){
                        g.AddComponent<Infection>().virusNum = virusNum;
                        isSpreading = false;
                        StartCoroutine(cooldown());
                    }
                }
            }
            if(! transform.GetComponent<BodyPart>().isAlive){
                viruses = 0;
                    foreach(GameObject g in spritesLive){
                        Destroy(g);
                    }
                    VirusDeathSlider.sliderDeathIns.value = 100 - transform.GetComponent<BodyPart>().health;
                    VirusAmountSlider.VirusSliderIns.value = 0;
                    if(isSelected){
                        VirusAmountText.virusAmountTextInstance.text = "BRAK SYGNAŁU";
                    }
                    foreach(int i in currBacs){
                        BodyValues.bodyParts[nameNumber - 1].transform.GetChild(i - 1).gameObject.SetActive(false);
                    }
                    Destroy(this);
            }
        }

        if(isCured && viruses < maxViruses / 100 && spreadLock > 0 || viruses < 1){
            multiplier = -0.5f;
        }

        if(viruses < 1){
            viruses = 0;
            foreach(GameObject g in spritesLive){
                        Destroy(g);
                    }
                    VirusDeathSlider.sliderDeathIns.value = 100 - transform.GetComponent<BodyPart>().health;
                    VirusAmountSlider.VirusSliderIns.value = 0;
                    foreach(int i in currBacs){
                        BodyValues.bodyParts[nameNumber - 1].transform.GetChild(i - 1).gameObject.SetActive(false);
                    }
                    if(transform.GetComponent<BodyPart>().isAlive) SoundManager.soundInstance.Play("zoneClear");
                    Destroy(this);
        }
    }

    void OnMouseDown() {
        if(EventManager.bacSelect != 0 && EventManager.bacSelect != 3){
            if(EventManager.bacSelect == 4 && antibody == bacs[3].transform.GetComponent<BCell>().antibody || EventManager.bacSelect != 4){
                if(!currBacs.Contains(EventManager.bacSelect) && EventManager.eventManagerIns.money >= bacs[EventManager.bacSelect - 1].price){
                    bacAttackerNum = EventManager.bacSelect;
                    EventManager.eventManagerIns.money -= bacs[EventManager.bacSelect - 1].price;
                    StartCoroutine(cured());
                }
            }
        }
        else if ( EventManager.bacSelect == 3){
            if(!currBacs.Contains(EventManager.bacSelect) && EventManager.eventManagerIns.money >= bacs[EventManager.bacSelect - 1].price){
                bacAttackerNum = EventManager.bacSelect;
                EventManager.eventManagerIns.money -= bacs[EventManager.bacSelect - 1].price;
                StartCoroutine(analyze());
            }
        }
        
        VirusAmountText.virusAmountTextInstance.text = "ilość wirusów: " + ((int) viruses).ToString("n", new NumberFormatInfo{NumberGroupSeparator = " "}).Remove(((int) viruses).ToString("n", new NumberFormatInfo{NumberGroupSeparator = " "}).Length - 3);
        if(!transform.GetComponent<BodyPart>().isAlive){
            VirusAmountText.virusAmountTextInstance.text = "BRAK SYGNAŁU";
        }
        VirusDeathSlider.sliderDeathIns.value = 100 - transform.GetComponent<BodyPart>().health;
        VirusAmountSlider.VirusSliderIns.maxValue = maxViruses;
        if(viruses > 25000000){
            VirusAmountSlider.VirusSliderIns.value = viruses;
        }
        else{
            VirusAmountSlider.VirusSliderIns.value = 25000000;
        }
        
        isSelected = true;
    }


    private IEnumerator disease(){
        isSpawningSp = true;
        while(true){
            if(viruses <= 5){
                if(viruses > currentViruses + 1){
                GameObject bac = Instantiate(virus, new Vector3(0, 0, 0), Quaternion.identity);
                spritesLive.Add(bac);
                bac.transform.SetParent(GameObject.Find("Canvas").transform);
                bac.GetComponent<SpawnInBorder>().target = this.transform;
                currentViruses++;
                }
            }
            else{
                if(currentViruses <= (int) BodyValues.partFunctions[nameNumber](viruses) && currentViruses <= maxSprites){
                    GameObject bac = Instantiate(virus, new Vector3(0, 0, 0), Quaternion.identity);
                    spritesLive.Add(bac);
                    bac.transform.SetParent(GameObject.Find("Canvas").transform);
                    bac.GetComponent<SpawnInBorder>().target = this.transform;
                    currentViruses++;
                }
                else if (currentViruses > maxSprites){
                    isSpawningSp = false;
                    StopCoroutine("disease");
                } 
            } 
            yield return new WaitForSeconds(Random.Range(0.15f, 0.05f));
        }
    }

    private IEnumerator cured(){
        isCured = true;
        currBacs.Add(bacAttackerNum);
        int attacker = bacAttackerNum;
        int duration = bacs[attacker - 1].longevity;
        int lifeTime = duration + Random.Range(-bacs[attacker - 1].randomLife, bacs[attacker - 1].randomLife / 4);
        GameObject attackerPop = BodyValues.bodyParts[nameNumber - 1].transform.GetChild(attacker - 1).gameObject;
        attackerPop.SetActive(true);

        if(attacker == 1 && virusNum == 6 ||attacker == 1 && virusNum == 3 || attacker == 2 && virusNum == 4|| attacker == 4 && virusNum == 5 || attacker == 2 && virusNum == 1 || attacker == 2 && virusNum == 2){
            multiplier -= bacs[attacker - 1].multiplier * 2f;
        }  
        else if(attacker == 4 && virusNum == 4 || attacker == 1 && virusNum == 1 || attacker == 2 && virusNum == 6 || attacker == 1 && virusNum == 2 || attacker == 4 && virusNum == 2){
            multiplier -= bacs[attacker - 1].multiplier * 0.75f;
        }
        else{
            multiplier -= bacs[attacker - 1].multiplier;
        }

        for(int i = 0; i <= lifeTime; i++){
            float tickWait = tick + 1;
            if(lifeTime - i <= 6 && (lifeTime - i) % 2 == 0){
                attackerPop.SetActive(false);
            }
            else if (lifeTime - i <= 6 && (lifeTime - i) % 2 == 1){
                attackerPop.SetActive(true);
            }
            while(tickWait >= tick){
                yield return 0;
            }
            if(duration != bacs[attacker - 1].longevity){
                duration = bacs[attacker - 1].longevity;
                lifeTime = duration + Random.Range(-bacs[attacker - 1].randomLife, bacs[attacker - 1].randomLife / 4);
            }
        }
        if(attacker == 1 && virusNum == 6  || attacker == 1 && virusNum == 3 || attacker == 2 && virusNum == 4|| attacker == 4 && virusNum == 5 || attacker == 2 && virusNum == 1 || attacker == 2 && virusNum == 2){
            multiplier += bacs[attacker - 1].multiplier * 2f;
        }  
        else if(attacker == 4 && virusNum == 4 || attacker == 1 && virusNum == 1 || attacker == 2 && virusNum == 6 || attacker == 1 && virusNum == 2 || attacker == 4 && virusNum == 2){
            multiplier += bacs[attacker - 1].multiplier * 0.75f;
        }
        else{
            multiplier += bacs[attacker - 1].multiplier;
        }
        attackerPop.SetActive(false);
        currBacs.Remove(attacker);
        isCured = false;
    }

    private IEnumerator analyze(){
        currBacs.Add(bacAttackerNum);
        int attacker = bacAttackerNum;
        float attMultiplier = bacs[attacker - 1].multiplier;
        int duration = bacs[attacker - 1].longevity;
        int lifeTime = duration + Random.Range(-bacs[attacker - 1].randomLife, bacs[attacker - 1].randomLife / 4);
        GameObject attackerPop = BodyValues.bodyParts[nameNumber - 1].transform.GetChild(attacker - 1).gameObject;
        attackerPop.SetActive(true);
        
        for(int i = 0; i < lifeTime; i++){
            float tickWait = tick + 1;
            if(lifeTime - i <= 6 && (lifeTime - i) % 2 == 0){
                attackerPop.SetActive(false);
            }
            else if (lifeTime - i <= 6 && (lifeTime - i) % 2 == 1){
                attackerPop.SetActive(true);
            } else if (lifeTime - 1 > 6){
                attackerPop.SetActive(true);
            }
            while(tickWait >= tick){
                yield return 0;
            }
            if(duration != bacs[attacker - 1].longevity){
                duration = bacs[attacker - 1].longevity;
                lifeTime = duration + Random.Range(-bacs[attacker - 1].randomLife, bacs[attacker].randomLife / 4);
            }
        }
        int rand = Random.Range(0, 101);
        if(rand <= attMultiplier){
            Camera.main.GetComponent<EnemyInformationShower>().spawnInformation(virusNum);

        }

        attackerPop.SetActive(false);
        currBacs.Remove(attacker);
    }

    private IEnumerator removeSprite(){
        int i = 0;
        while(true){
            if(spritesLive.Count > 0 && currentViruses - 1 > (int) BodyValues.partFunctions[nameNumber](viruses) && currentViruses > 5){
                Destroy(spritesLive[i]);
                currentViruses--;
                i++;
                if(!isSpawningSp){
                    StartCoroutine(disease());
                }
            }
            yield return new WaitForSeconds(Random.Range(0.15f, 0.05f));
        }
    }

    private IEnumerator invincibility(){
        float tickWait = tick + 60;
            while(tickWait >= tick){
                yield return 0;
            }
            spreadLock = 1;
    }

    private IEnumerator cooldown(){
        float tickWait = tick + 10;
            while(tickWait >= tick){
                yield return 0;
            }
        isSpreading = true;
    }
}
