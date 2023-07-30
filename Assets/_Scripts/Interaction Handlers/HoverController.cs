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
        IHoverable hover = CurrentNPC as IHoverable;
        hover?.OnHoverExit();
    }

    public void HandleAfterNPCChange()
    {
        IHoverable hover = CurrentNPC as IHoverable;
        hover?.OnHover();
    }

    // public void HandleClick()
    // {
    //     if(Input.GetMouseButtonDown(0))
    //     {
    //         var temp = CheckPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));

    //         if(temp != null)
    //             currentNPC = temp;
    //     }
    // }

    // private void HandleCurrentNPCChange()
    // {
    //     UIManager.Instance.UpdateNPCDetails(currentNPC.npcDetails);
    //     UIManager.Instance.ToggleUIElement(UIManager.Instance.npcDetailsUI, true);

    // }

    // public void RevertToCurrentClickedNPC()
    // {
    //     UIManager.Instance.UpdateNPCDetails(currentNPC.npcDetails);
    // }

    void OnDrawGizmos()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawWireSphere(mousePos, checkRadius);
    } 

}
