using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static ClickManager Instance {get; private set;}

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

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else   
            Destroy(gameObject);
    }

    void Update()
    {
        HandleClick();
    }

    public void HandleClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
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

    public void ShowCurrentNPC()
    {
        if(CurrentNPC == null)
            return;

        IClickable clickable = CurrentNPC as IClickable;
        clickable?.OnClickExit();
    }
}
