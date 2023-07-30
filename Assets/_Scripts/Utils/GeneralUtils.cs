using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class GeneralUtils
{
    public static NPCController CheckPosition(Vector2 pos, float radius)
    {
        // Check for obejcts around mouse pos
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, radius);
        Collider2D col = colliders.Where(collider => collider.GetComponent<IHoverable>() != null)
                            .OrderBy(collider => collider.gameObject.GetInstanceID())
                            .FirstOrDefault();

        if(col != null)
        {
            if(col.gameObject.CompareTag("NPC"))
                return col.GetComponent<NPCController>();
        }

        return null;
    }
}
