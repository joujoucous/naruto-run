using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingCloud : MonoBehaviour
{
    Vector3 pos ;
    [SerializeField] float coef ;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pos= transform.position;
        pos.y+=Mathf.Cos(Time.time)*coef;
        transform.position=pos;
    }
}
