using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StudentMarks
{
    public string marksString;

    public StudentMarks()
    {
        marksString = UserDataBase.marksInput;
    }

}
