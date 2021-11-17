using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Notice
{
    public String noticeSubject;
    public String noticeDiscription;
    public String noticeUrl;

    public Notice()
    {
        noticeSubject = UserDataBase.eventNameInput;
        noticeDiscription = UserDataBase.eventDiscriptionInput;
        noticeUrl = UserDataBase.eventUrlInput;
    }

}
