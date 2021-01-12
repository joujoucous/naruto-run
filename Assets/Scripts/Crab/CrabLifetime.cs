using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabLifetime : MonoBehaviour
{

    public float lifetime = 60.0f;

    private void Awake()
    {
        Destroy(this.gameObject, lifetime);
    }
}
