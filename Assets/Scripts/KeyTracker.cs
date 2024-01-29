using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTracker : MonoBehaviour
{
    public bool hasBronzeKey = false;
    public bool hasSilverKey = false;
    public bool hasGoldKey = false;
    public bool hasBlackKey = false;

    public bool CanOpenBronzeDoor()
    {
        return hasBronzeKey;
    }

    public bool CanOpenSilverDoor()
    {
        return hasSilverKey;
    }

    public bool CanOpenGoldDoor()
    {
        return hasGoldKey;
    }

    public bool CanOpenBlackDoor()
    {
        return hasBlackKey;
    }
}
