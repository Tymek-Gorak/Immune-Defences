using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static int bacSelect = 0;
    public static bool clicked = false;
    public int money = 0;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] public int days = 0;
    private float tick = 0;
    private float time = 0;
    public static int timeSpeed = 1;
    private int savedTSpeed = 0;
    [SerializeField] private GameObject speedDisplay;
    [SerializeField] private GameObject moneyDisplay;
    private List<int> waveOrder1 = new List<int>(){1, 1, 2, 3, 7, 9, 10, 6, 5, 15};
    private List<int> waveOrder2 = new List<int>(){1, 2, 2, 16, 4, 7, 8, 4, 11, 14};
    private List<int> waveOrder3 = new List<int>(){1, 5, 7, 2, 10, 2, 16, 9, 12, 13};
    



    private static EventManager eventManager;
    public static EventManager eventManagerIns{
        get{
            if (eventManager == null) eventManager = Camera.main.transform.GetComponent<EventManager>();
            return eventManager;
        }
    }

    private bool isViruses{ get{
        foreach(GameObject bodyPart in BodyValues.bodyParts){
            if(bodyPart.GetComponent<Infection>() != null){
                return true;
            }
        }
        return false;
    }}

    void Start()
    {
        StartCoroutine(passiveCash());
        StartCoroutine(waves());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            timeSpeed -= 1;
        }
        else if(Input.GetKeyDown(KeyCode.E)){
            timeSpeed += 1;
        }
        else if(Input.GetKeyDown(KeyCode.Space)){
            if(timeSpeed != 0){
                savedTSpeed = timeSpeed;
            }
            if(timeSpeed == 0){
                timeSpeed = savedTSpeed;
            }
            else{
                timeSpeed = 0;
            }
        }
        timeSpeed = Mathf.Clamp(timeSpeed, 0, 3);
        money = Mathf.Clamp(money, 0, 99);
        speedDisplay.GetComponent<TextMeshProUGUI>().text = timeSpeed.ToString();
        moneyDisplay.GetComponent<TextMeshProUGUI>().text = money.ToString();

        time += Time.deltaTime * timeSpeed;
        if(time >= tick){
            tick += 1;
            days++;
        }

        if(clicked == true && Input.GetMouseButtonUp(0)){
            StartCoroutine(unClick());
        }

        bool b = isViruses;
        if(days >= 1000 && !b){
            win();
        }
    }

    public void win(){
        winScreen.SetActive(true);
        SoundManager.soundInstance.Play("win");
        winScreen.transform.GetChild(0).GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = days + " dni";
        Time.timeScale = 0;
    }

    public void lose(){
        SoundManager.soundInstance.Play("lose");
        loseScreen.SetActive(true);
        winScreen.transform.GetChild(0).GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = days + " dni";
        Time.timeScale = 0;
    }

    private IEnumerator unClick(){
        yield return 0;
        clicked = false;
        bacSelect = 0;
    }

    private IEnumerator passiveCash(){
        while(true){    
            float tickWait = tick + 5;
            while(tickWait >= tick){
                yield return 0;
            }
            money += 2;
        }
    }

    private IEnumerator waves(){
        int nextWave = 1;
        while(true){ 
            if(nextWave != 11){
            int rand = Random.Range(0, 3);
            if(rand == 0){
                foreach(GameObject virus in BodyValues.waveList[waveOrder1[nextWave - 1]]){
                    Instantiate(virus, new Vector3(0, 0, 0), Quaternion.identity);
                }

            }
            else if (rand == 1){
                foreach(GameObject virus in BodyValues.waveList[waveOrder2[nextWave - 1]]){
                    Instantiate(virus, new Vector3(0, 0, 0), Quaternion.identity);

                }
            }
            else {
                foreach(GameObject virus in BodyValues.waveList[waveOrder3[nextWave - 1]]){
                    Instantiate(virus, new Vector3(0, 0, 0), Quaternion.identity);
                }
            }

            
            

            nextWave++;
            
            
            }
            float tickWait = tick + 98;
            while(tickWait >= tick){
                yield return 0;
            }
        }
    }
}
