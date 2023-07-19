using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementBase : MonoBehaviour, IUIElement
{
    public GameObject uiElement;

    public void ToggleUiElement(bool show)
    {
        uiElement?.SetActive(show);
    }
}
