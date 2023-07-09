using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 spawnArea;
    public GameObject container;

    public void Spawn()
    {

        Vector3 pos = new Vector2(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y));

        RaycastHit2D hit = Physics2D.CircleCast(pos,1f,Vector2.zero);

        // if(hit)
        //     return;

        var newNPC = Instantiate(prefab, pos, Quaternion.identity, container.transform.parent);



        var npcDetails = PersonFactory.CreatePerson(12, 65);
        newNPC.GetComponent<NPCController>().Init(npcDetails);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }
}
