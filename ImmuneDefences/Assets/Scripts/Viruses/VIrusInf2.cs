using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIrusInf2 : VirusInf1
{
    new void Start()
    {
        startViruses = base.startViruses;
        virusNumber = 2;
        base.Start();
        base.Update();
    }

}
