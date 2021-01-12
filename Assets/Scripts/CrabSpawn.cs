using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawn : MonoBehaviour
{

    public float spawnTime_s = 12.0f;
    float timer_s = 0.0f;
    public float direction = 0.0f;
    public GameObject Crab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Crab, transform.position, Quaternion.Euler(0, direction, 0));
    }

    // Update is called once per frame
    void Update()
    {
        timer_s += Time.deltaTime;
        if (timer_s >= spawnTime_s)
        {
            Instantiate(Crab, transform.position, Quaternion.Euler(0, direction, 0));
            timer_s = 0.0f;
        }
    }
}
