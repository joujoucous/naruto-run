using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockSpawn : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position = new Vector3(0, 100, 0);
    }
}
