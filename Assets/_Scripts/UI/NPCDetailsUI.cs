using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCDetailsUI : UIElementBase
{
    [Header("UI Elements")]
    public TMP_Text ageText;
    public TMP_Text potentailText;
    public TMP_Text traitText;

    public void UpdateDetails(Person details)
    {
        ageText.text = details.age.ToString();
        potentailText.text = details.potential.ToString();
        traitText.text = details.trait.ToString();
    }
}
