using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreInf : VirusInf1
{
    // Start is called before the first frame update
    new void Start()
    {
        startViruses = base.startViruses;
        virusNumber = 3;
        base.Start();
        base.Update();
    }
}
