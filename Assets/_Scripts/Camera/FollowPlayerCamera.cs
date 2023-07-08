using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public bool canMove = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!canMove || target == null)
            return;

        // Make camera move from current position to smooth position which is one point closer to desired Pos
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPos;
    }

    /// <summary>
    /// Make the camera point towards the target and allow movement 
    /// </summary>
    public void SetUp(Transform followTarget)
    {
        target = followTarget;
        canMove = true;
        transform.position = new Vector3(target.transform.position.x,0,0) + offset;
    }
}
