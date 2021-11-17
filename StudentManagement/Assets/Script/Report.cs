using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Report
{

    public string dat;

    public Report()
    {
        dat = UserDataBase.reportData;
    }

}
