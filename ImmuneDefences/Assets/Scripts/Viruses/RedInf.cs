using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedInf : VirusInf1
{
    // Start is called before the first frame update
    new void Start()
    {
        startViruses = base.startViruses;
        virusNumber = 4;
        base.Start();
        base.Update();
    }

    // U
    
}
