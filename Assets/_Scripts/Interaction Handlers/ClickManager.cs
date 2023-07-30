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
            if(currentNPC != value)
            {
                BeforeNPCChange();
                currentNPC = value; 
                AfterNPCChange();
            }
        }
    }

    void Update()
    {
        HandleClick();
    }

    public void HandleClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Do it");
            var temp = GeneralUtils.CheckPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition), .5f);

            if(temp != null && temp is IClickable)
            {
                CurrentNPC = temp;
            }
        }
    }

    public void BeforeNPCChange()
    {
        if(CurrentNPC == null)
            return;

        IClickable clickable = CurrentNPC as IClickable;
        clickable?.OnClickExit();
    }

    public void AfterNPCChange()
    {
        if(CurrentNPC == null)
            return;

        IClickable clickable = CurrentNPC as IClickable;
        clickable?.OnClick();
    }
}
