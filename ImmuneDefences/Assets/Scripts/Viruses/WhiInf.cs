using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiInf : VirusInf1
{
    // Start is called before the first frame update
    new void Start()
    {
        startViruses = base.startViruses;
        virusNumber = 6;
        base.Start();
        base.Update();
    }

}
