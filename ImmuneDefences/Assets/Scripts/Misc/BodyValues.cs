using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class BodyValues : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    public static Dictionary<int, Tuple<int, int, float, float, List<GameObject>>> bodyValues = new Dictionary<int, Tuple<int, int, float, float, List<GameObject>>>();
    public static GameObject[] bodyParts;
    public static Dictionary<int, string> partNames = new Dictionary<int, string>();
    public static Dictionary<int, Func<float, float>> partFunctions = new Dictionary<int, Func<float, float>>();
    public static Dictionary<int, Bac> bacs = new Dictionary<int, Bac>();
    public static Dictionary<int, Tuple<int, float, GameObject, float, int, float, int>> virusAntibodies = new Dictionary<int, Tuple<int, float, GameObject, float, int, float, int>>();
    public static Dictionary<int, List<GameObject>> waveList = new Dictionary<int, List<GameObject>>();

    float fun10(float viruses){
        return 0.000000278f * viruses + 1f;
    }
    float fun15(float viruses){
        return 0.0000001853333f * viruses + 1f;
    }
    float fun20(float viruses){
        return 0.000000139f * viruses + 1f;
    }
    float fun75(float viruses){
        return 0.000000370667f * viruses + 1f;
    }
    
    void Awake() {
        bodyParts = new GameObject[11] {         
        GameObject.Find("body1"),
        GameObject.Find("body2"),
        GameObject.Find("body3"),
        GameObject.Find("body4"),
        GameObject.Find("body5"),
        GameObject.Find("body6"),
        GameObject.Find("body7"),
        GameObject.Find("body8"),
        GameObject.Find("body9"),
        GameObject.Find("body10"),
        GameObject.Find("body11")
        };

        bodyValues.Clear();
        partNames.Clear();
        partFunctions.Clear();
        bacs.Clear();
        virusAntibodies.Clear();
        waveList.Clear();

        bodyValues.Add(1, new Tuple<int, int, float, float, List<GameObject>>(1500000000, 170, 3.350827f, 1.002625f, new List<GameObject>(){bodyParts[2]}));
        bodyValues.Add(2, new Tuple<int, int, float, float, List<GameObject>>(1000000000, 140, 3.338217f, 1.003752f, new List<GameObject>(){bodyParts[2], bodyParts[4]}));
        bodyValues.Add(3, new Tuple<int, int, float, float, List<GameObject>>(750000000, 170, 3.358115f, 1.001966f, new List<GameObject>(){bodyParts[0], bodyParts[1], bodyParts[3], bodyParts[5]}));
        bodyValues.Add(4, new Tuple<int, int, float, float, List<GameObject>>(1000000000, 140, 3.338217f, 1.003752f, new List<GameObject>(){bodyParts[2], bodyParts[6]}));
        bodyValues.Add(5, new Tuple<int, int, float, float, List<GameObject>>(750000000,  140, 3.324323f, 1.005015f, new List<GameObject>(){bodyParts[1]}));
        bodyValues.Add(6, new Tuple<int, int, float, float, List<GameObject>>(1500000000, 170, 3.350827f, 1.002625f, new List<GameObject>(){bodyParts[2], bodyParts[7], bodyParts[8]}));
        bodyValues.Add(7, new Tuple<int, int, float, float, List<GameObject>>(750000000,  140, 3.324323f, 1.005015f, new List<GameObject>(){bodyParts[3]}));
        bodyValues.Add(8, new Tuple<int, int, float, float, List<GameObject>>(1000000000, 140, 3.338217f, 1.003752f, new List<GameObject>(){bodyParts[5], bodyParts[9]}));
        bodyValues.Add(9, new Tuple<int, int, float, float, List<GameObject>>(1000000000, 140, 3.338217f, 1.003752f, new List<GameObject>(){bodyParts[5], bodyParts[10]}));
        bodyValues.Add(10, new Tuple<int, int, float, float, List<GameObject>>(750000000, 140, 3.324323f, 1.005015f, new List<GameObject>(){bodyParts[7]}));
        bodyValues.Add(11, new Tuple<int, int, float, float, List<GameObject>>(750000000, 140, 3.324323f, 1.005015f, new List<GameObject>(){bodyParts[8]}));
    
        partNames.Add(1, "Głowa");
        partNames.Add(2, "Prawe ramię");
        partNames.Add(3, "Klatka pierśiowa");
        partNames.Add(4, "Lewe ramię");
        partNames.Add(5, "Prawe przedramię");
        partNames.Add(6, "Brzuch");
        partNames.Add(7, "Lewe przedramię");
        partNames.Add(8, "Prawe udo");
        partNames.Add(9, "Lewe udo");
        partNames.Add(10, "Prawe podudzie");
        partNames.Add(11, "Lewe podudzie");
    
        partFunctions.Add(1, new Func<float, float>(fun15));
        partFunctions.Add(2, new Func<float, float>(fun10));
        partFunctions.Add(3, new Func<float, float>(fun20));
        partFunctions.Add(4, new Func<float, float>(fun10));
        partFunctions.Add(5, new Func<float, float>(fun75));
        partFunctions.Add(6, new Func<float, float>(fun15));
        partFunctions.Add(7, new Func<float, float>(fun75));
        partFunctions.Add(8, new Func<float, float>(fun10));
        partFunctions.Add(9, new Func<float, float>(fun10));
        partFunctions.Add(10, new Func<float, float>(fun75));
        partFunctions.Add(11, new Func<float, float>(fun75));

        bacs.Add(1, GameObject.Find("macrophage").GetComponent<Bac>());
        bacs.Add(3, GameObject.Find("tentacle").GetComponent<Bac>());
        bacs.Add(2, GameObject.Find("kamikaze").GetComponent<Bac>());
        bacs.Add(4, GameObject.Find("bCell").GetComponent<Bac>());

        virusAntibodies.Add(1, new Tuple<int, float, GameObject, float, int, float, int>(4, 0.2f, (GameObject) Resources.Load("Virus1")        , 0.06f, 15000000, 1.7f, 6));
        virusAntibodies.Add(2, new Tuple<int, float, GameObject, float, int, float, int>(5, .45f, (GameObject) Resources.Load("Virus2_0")   , 0.14f, 25000000, 2.5f, 7));
        virusAntibodies.Add(3, new Tuple<int, float, GameObject, float, int, float, int>(1, 0.2f, (GameObject) Resources.Load("bacteria1_0"), .06f, 50000000, 1.1f, 5));
        virusAntibodies.Add(4, new Tuple<int, float, GameObject, float, int, float, int>(3, 1f, (GameObject) Resources.Load("bacteria3_0")   , 0.08f, 15000000, 0.8f, 5));
        virusAntibodies.Add(5, new Tuple<int, float, GameObject, float, int, float, int>(6, .5f, (GameObject) Resources.Load("bacteria2_0")   , 0.1f, 40000000, 1.5f, 6));
        virusAntibodies.Add(6, new Tuple<int, float, GameObject, float, int, float, int>(2, 0.3f, (GameObject) Resources.Load("bacteria6_0"), 0.09f, 5000000, 1.6f, 6));


        waveList.Add(1, new List<GameObject>(){enemies[2]});
        waveList.Add(2, new List<GameObject>(){enemies[3]});
        waveList.Add(3, new List<GameObject>(){enemies[4]});
        waveList.Add(4, new List<GameObject>(){enemies[0]});
        waveList.Add(5, new List<GameObject>(){enemies[5]});
        waveList.Add(6, new List<GameObject>(){enemies[1]});

        waveList.Add(7,  new List<GameObject>(){enemies[2], enemies[3]});
        waveList.Add(8,  new List<GameObject>(){enemies[3], enemies[0]});
        waveList.Add(9,  new List<GameObject>(){enemies[4], enemies[2]});
        waveList.Add(10, new List<GameObject>(){enemies[5], enemies[2]});
        waveList.Add(11, new List<GameObject>(){enemies[1], enemies[3]});
        waveList.Add(12, new List<GameObject>(){enemies[1], enemies[5]});
        
        waveList.Add(13, new List<GameObject>(){enemies[2], enemies[4], enemies[2]});
        waveList.Add(14, new List<GameObject>(){enemies[3], enemies[2], enemies[5]});
        waveList.Add(15, new List<GameObject>(){enemies[1], enemies[5], enemies[5]});

        waveList.Add(16, new List<GameObject>(){enemies[2], enemies[2]});
    }

}
