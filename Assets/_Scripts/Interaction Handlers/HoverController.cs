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

    // private NPCController currentClickedNPC;
    // public NPCController CurrentClickedNPC
    // {
    //     get { return currentClickedNPC
    //     ; }
    //     set { currentClickedNPC
    //      = value; }
    // }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var npc = CheckPosition(mousePos);

       CurrentNPC = npc;

        // if(npc != null)
        // {
        //     CurrentNPC = npc;
        // }  
        // else 
        // {
        //     HandleBeforeNPCChange();
        //     CurrentNPC = null;
        // }
    }

    public NPCController CheckPosition(Vector2 pos)
    {
        // Check for obejcts around mouse pos
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, checkRadius);
        Collider2D col = colliders.Where(collider => collider.GetComponent<IHover>() != null)
                            .OrderBy(collider => collider.gameObject.GetInstanceID())
                            .FirstOrDefault();

        if(col != null)
        {
            if(col.gameObject.CompareTag("NPC"))
                return col.GetComponent<NPCController>();
        }

        return null;
    }

    public void HandleBeforeNPCChange()
    {
        IHover hover = CurrentNPC as IHover;
        hover?.OnHoverExit();
    }

    public void HandleAfterNPCChange()
    {
        IHover hover = CurrentNPC as IHover;
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
