using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : UIElementBase
{
    [Header("UI Elements")]
    public TMP_Text ageText;
    public TMP_Text potentailText;
    public TMP_Text traitText;

    public void UpdateUIContent(Quest quest)
    {
        ageText.text = quest.age.ToString();
        potentailText.text = quest.potential.ToString();
        traitText.text = quest.trait.ToString();
    }
}
