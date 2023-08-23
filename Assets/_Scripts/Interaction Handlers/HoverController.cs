using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class HoverController : MonoBehaviour
{
    public float checkRadius = 1f;

    private NPCController currentNPC;
    public NPCController CurrentNPC
    {
        get { return currentNPC; }
        set 
        { 
            if(currentNPC != value)
            {
                BeforeChange();
                currentNPC = value; 
                AfterChange();
            }
        }
    }

    void Awake()
    {
        Configure();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var npc = GeneralUtils.CheckPosition(mousePos, checkRadius);

        CurrentNPC = npc;
    }

    public void Configure()
    {
        GameEvents.Instance.onNPCDied += HandleNPCDeath;
    }

    public void BeforeChange()
    {
        if(CurrentNPC == null)
            return;

        IHoverable hover = CurrentNPC as IHoverable;
        hover?.OnHoverExit();
    }

    public void AfterChange()
    {
        if(CurrentNPC == null)
        {
            return;
        }

        IHoverable hover = CurrentNPC as IHoverable;
        hover?.OnHover();
    }

    public void HandleNPCDeath(NPCController npc)
    {
        if (CurrentNPC == npc)
        {
            CurrentNPC = null;
        }
    }

    void OnDrawGizmos()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawWireSphere(mousePos, checkRadius);
    } 
}
