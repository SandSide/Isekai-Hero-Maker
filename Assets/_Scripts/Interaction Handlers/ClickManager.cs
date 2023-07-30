using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private NPCController currentNPC;
    public NPCController CurrentNPC
    {
        get  { return currentNPC; }
        set 
        { 
            currentNPC = value; 
        }
    }
}
