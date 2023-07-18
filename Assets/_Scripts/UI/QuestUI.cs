using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text ageText;
    public TMP_Text potentailText;
    public TMP_Text traitText;

    public void Update(Quest quest)
    {
        ageText.text = quest.age.ToString();
        potentailText.text = quest.potential.ToString();
        traitText.text = quest.trait.ToString();
    }
}
