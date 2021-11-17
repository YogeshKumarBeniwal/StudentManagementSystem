using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EventDetails
{
    public string eventDecription;
    public string eventName;
    public string eventUrl;
    public string eventDuration;

    public EventDetails()
    {
        eventName = UserDataBase.eventNameInput;
        eventDecription = UserDataBase.eventDiscriptionInput;
        eventUrl = UserDataBase.eventUrlInput;
    }
}
