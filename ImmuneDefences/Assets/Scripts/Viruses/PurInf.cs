using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurInf : VirusInf1
{
    // Start is called before the first frame update
    new void Start()
    {
        startViruses = base.startViruses;
        virusNumber = 5;
        base.Start();
        base.Update();
    }

    // Update is calle
}
