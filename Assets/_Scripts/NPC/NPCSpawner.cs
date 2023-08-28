using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NPCSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 spawnArea;
    public GameObject container;

    public int maxAttemps = 10;
    public float spawnCheckArea = 1f;
    public int amountSpawned = 0;
    
    private Vector2 centerOffset;

    void Awake()
    {
        centerOffset = new Vector2(spawnArea.x/2, spawnArea.y/2);
    }

    public void Spawn()
    {

        int attempts = 0;

        while(attempts < maxAttemps)
        {
            Vector3 pos = new Vector2(Random.Range(-centerOffset.x, centerOffset.x), Random.Range(-centerOffset.y, centerOffset.y));

            RaycastHit2D hit = Physics2D.CircleCast(pos, spawnCheckArea, Vector2.zero);

            if(!hit)
            {
                var newNPC = Instantiate(prefab, pos, Quaternion.identity, container.transform.parent);
                var npcDetails = PersonFactory.CreatePerson(12, 65);
                newNPC.GetComponent<NPCController>().Init(npcDetails);
                amountSpawned++;
                return;
            }
            else
            {
                attempts++;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, spawnArea);
        centerOffset = new Vector2(spawnArea.x/2, spawnArea.y/2);

        for (int i = (int)-centerOffset.x; i <= (int)centerOffset.x; i++)
        {
            for (int j = (int)-centerOffset.y; j <= (int)centerOffset.y; j++)
            {
                Vector3 pos = new Vector2(i,j);
                
                RaycastHit2D hit = Physics2D.CircleCast(pos, spawnCheckArea, Vector2.zero);

                Gizmos.color = hit ? Color.red : Color.white;
                Gizmos.DrawSphere(pos, spawnCheckArea);
            }
        }     
    }
}
