using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Students
{
    public string studentEmail;
    public string studentRollNo;

    public Students()
    {
        studentEmail = UserDataBase.studentEmailId;
        studentRollNo = UserDataBase.studentRollNo;
    }

}
