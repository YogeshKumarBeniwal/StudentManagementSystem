using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AdminData
{
    public string adminEmail;
    public string adminName;
    //public string adminlocalId;

    public AdminData()
    {
        adminEmail = UserDataBase.adminEmailInput;
        adminName = UserDataBase.adminNameInput;
    }
}
