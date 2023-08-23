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
                BeforeChange();
                currentNPC = value; 
                AfterChange();
            }
        }
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else   
        {
            Destroy(gameObject);
            return;
        }
            
        Configuration();
    }

    void Update()
    {
        HandleClick();
    }

    public void Configuration()
    {
        GameEvents.Instance.onNPCDied += HandleNPCDeath;
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

    public void BeforeChange()
    {
        if(CurrentNPC == null)
            return;

        IClickable clickable = CurrentNPC as IClickable;
        clickable?.OnClickExit();
    }

    public void AfterChange()
    {
        if(CurrentNPC == null)
        {
            Debug.Log($"Remove CLICKED NPC UI");
            return;
        }
     
        IClickable clickable = CurrentNPC as IClickable;
        clickable?.OnClick();
    }

    public void HandleNPCDeath(NPCController npc)
    {
        if(CurrentNPC == npc)
        {
            CurrentNPC = null;
        }
    }

    public void ShowCurrentNPC()
    {
        if(CurrentNPC == null)
            return;

        IClickable clickable = CurrentNPC as IClickable;
        clickable?.OnClickExit();
    }
}
