using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CountProblems
{

    public int totalNoOfProblems;

    public CountProblems()
    {
        totalNoOfProblems = UserDataBase.numberOfProb;
    }

}
