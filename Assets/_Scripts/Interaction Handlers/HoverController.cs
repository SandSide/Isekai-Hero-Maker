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
                HandleBeforeNPCChange();
                currentNPC = value; 
                HandleAfterNPCChange();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var npc = GeneralUtils.CheckPosition(mousePos, checkRadius);

        CurrentNPC = npc;

    }

    public void HandleBeforeNPCChange()
    {
        if(CurrentNPC == null)
            return;

        IHoverable hover = CurrentNPC as IHoverable;
        hover?.OnHoverExit();
    }

    public void HandleAfterNPCChange()
    {
        if(CurrentNPC == null)
        {
            //GetComponent<ClickManager>().ShowCurrentNPC();
            return;
        }


        IHoverable hover = CurrentNPC as IHoverable;
        hover?.OnHover();
    }

    void OnDrawGizmos()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawWireSphere(mousePos, checkRadius);
    } 

}
