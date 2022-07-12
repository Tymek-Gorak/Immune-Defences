using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformationShower : MonoBehaviour
{
    [SerializeField] private GameObject[] informations;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnInformation(int i){
        SoundManager.soundInstance.Play("denSuc");
        informations[i - 1].SetActive(true);
    }
}
