using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableItem : MonoBehaviour, IClickable
{
    public virtual void OnClick()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnClickExit()
    {
        throw new System.NotImplementedException();
    }

}
