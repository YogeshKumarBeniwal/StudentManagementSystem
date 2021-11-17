using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    public string userName;
    public string userEmail;
    public string localId;
    public string userDipartment;
    public string rollNo;
    
    public User()
    {
        rollNo = UserDataBase.studentRollNo;
        userName = UserDataBase.studentName;
        userEmail = UserDataBase.studentEmailId;
        userDipartment = UserDataBase.studentBranch;
        localId = UserDataBase.localId;
    }
}
