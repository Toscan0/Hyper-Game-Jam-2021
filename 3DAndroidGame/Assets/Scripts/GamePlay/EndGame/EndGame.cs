using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EndGame : MonoBehaviour
{
    public enum zone { BOT, TOP}

    public zone zoneType;

    public static bool topTriggered = false;
    public static bool botTriggered = false;

    
}
