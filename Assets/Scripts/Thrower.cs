using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    
    public GameObject bombPrefab;
    public float Timer;
    public Vector3 spawnpos;
    GameObject bomb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player");
        
        Timer -= Time.deltaTime;
        if (Timer <= 0f && player != null)
        {
            bomb = Instantiate(bombPrefab, spawnpos, transform.rotation) as GameObject;
            Timer = 2f;
        }
        else if(Timer <= 0f && player == null)
        {
            Timer = 2f;
        }
    }
}
