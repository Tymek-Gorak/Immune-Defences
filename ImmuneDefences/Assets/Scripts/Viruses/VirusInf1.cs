using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusInf1 : MonoBehaviour
{
    protected int virusNumber = 1;
    protected int partSpawn;
    protected int random;
    protected int i = 0;
    protected int startViruses = 50000000;

    protected void Start()
    {
        random = Random.Range(0, 50);
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if(i == random){
                partSpawn = Random.Range(1, 5);
            if (partSpawn == 1){
                if(BodyValues.bodyParts[5 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[5 - 1].GetComponent<Infection>() == null) {
                    
                    Infection i = BodyValues.bodyParts[5 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if (BodyValues.bodyParts[2 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[2 - 1].GetComponent<Infection>() == null ){
                    
                    Infection i = BodyValues.bodyParts[2 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if (BodyValues.bodyParts[3 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[3 - 1].GetComponent<Infection>() == null){
                    
                    Infection i = BodyValues.bodyParts[3 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if (BodyValues.bodyParts[1 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[1 - 1].GetComponent<Infection>() == null){
                    
                    Infection i = BodyValues.bodyParts[1 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else{
                    gameObject.AddComponent<VirusInf1>().virusNumber = virusNumber;
                    Destroy(this);
                }
                
            }
            else if(partSpawn == 2){ 
                if(BodyValues.bodyParts[7 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[7 - 1].GetComponent<Infection>() == null) {
                    
                    Infection i = BodyValues.bodyParts[7 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                }
                else if (BodyValues.bodyParts[4 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[4 - 1].GetComponent<Infection>() == null) {
                    
                    Infection i = BodyValues.bodyParts[3 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if (BodyValues.bodyParts[3 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[3 - 1].GetComponent<Infection>() == null){
                    
                    Infection i = BodyValues.bodyParts[3 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if (BodyValues.bodyParts[1 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[1 - 1].GetComponent<Infection>() == null){
                    
                    Infection i = BodyValues.bodyParts[1 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else{
                    gameObject.AddComponent<VirusInf1>().virusNumber = virusNumber;
                    Destroy(this);
                }
            }
            else if(partSpawn == 3){
                if(BodyValues.bodyParts[10 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[10 - 1].GetComponent<Infection>() == null) {
                    
                    Infection i = BodyValues.bodyParts[10 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;

                    
                }
                else if (BodyValues.bodyParts[8 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[8 - 1].GetComponent<Infection>() == null) {
                    
                    Infection i = BodyValues.bodyParts[8 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if (BodyValues.bodyParts[6 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[6 - 1].GetComponent<Infection>() == null){
                    
                    Infection i = BodyValues.bodyParts[6 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if (BodyValues.bodyParts[3 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[3 - 1].GetComponent<Infection>() == null){
                    
                    Infection i = BodyValues.bodyParts[3 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if(BodyValues.bodyParts[1 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[1 - 1].GetComponent<Infection>() == null){
                    
                    Infection i = BodyValues.bodyParts[1 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else{
                    gameObject.AddComponent<VirusInf1>().virusNumber = virusNumber;
                    Destroy(this);
                }
            }
            else if (partSpawn == 4){
                if(BodyValues.bodyParts[11 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[11 - 1].GetComponent<Infection>() == null) {
                    
                    Infection i = BodyValues.bodyParts[11 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;

                    
                }
                else if (BodyValues.bodyParts[9 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[9 - 1].GetComponent<Infection>() == null) {
                    
                    Infection i = BodyValues.bodyParts[9 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if (BodyValues.bodyParts[6 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[6 - 1].GetComponent<Infection>() == null){
                    
                    Infection i = BodyValues.bodyParts[6 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if (BodyValues.bodyParts[3 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[3 - 1].GetComponent<Infection>() == null){
                    
                    Infection i = BodyValues.bodyParts[3 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else if(BodyValues.bodyParts[1 - 1].GetComponent<BodyPart>().isAlive && BodyValues.bodyParts[1 - 1].GetComponent<Infection>() == null){
                    
                    Infection i = BodyValues.bodyParts[1 - 1].AddComponent<Infection>();
                    i.virusNum = virusNumber;
                    i.viruses = startViruses;
                    
                }
                else{
                    gameObject.AddComponent<VirusInf1>().virusNumber = virusNumber;
                    Destroy(this);
                }
            }
            Destroy(gameObject);
            }
        i++;
        
    }
}
