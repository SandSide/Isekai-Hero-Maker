using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public int maxNPC = 10;
    public NPCSpawner npcSpawner;

    public void SpawnNPCS()
    {
        for (int i = 0; i < maxNPC; i++)
        {
            npcSpawner.Spawn();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnNPCS();
    }
}
