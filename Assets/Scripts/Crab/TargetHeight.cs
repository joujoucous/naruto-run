using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Ce script permet à ce que le crabe puisse monter et descendre des pentes

public class TargetHeight : MonoBehaviour
{

    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        Vector3 ray = transform.position + new Vector3(0, 5, 0);
        Vector3 down_vect = transform.TransformDirection(Vector3.down) * 10;

        // On créé un raycast qui cherche la hauteur du sol
        if (Physics.Raycast(ray, down_vect, out hit, 50))
        {
            // On place le target à la hauteur du sol
            this.transform.position = new Vector3(this.transform.position.x, hit.point.y, this.transform.position.z);
            Debug.DrawRay(ray, down_vect, Color.green);
        }
    }
}
