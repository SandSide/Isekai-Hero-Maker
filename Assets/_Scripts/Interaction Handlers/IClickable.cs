using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable
{
    public bool IsClicked { get; set; }
    void OnClick();
    void OnClickExit();
}
