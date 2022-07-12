using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCell : Bac
{
    public int antibody = 0;

    void Start()
    {
        antibody = -1;
        multiplier = 0.1f;
        longevity = 25;
        randomLife = 5;
        price = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
