using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHeight : MonoBehaviour
{

    public float Height;
    public GameObject RightLeg1Target;
    public GameObject RightLeg2Target;
    public GameObject RightLeg3Target;
    public GameObject LeftLeg1Target;
    public GameObject LeftLeg2Target;
    public GameObject LeftLeg3Target;


    // Update is called once per frame
    void Update()
    {
        // Le corps de notre crabe est situé à une hauteur moyenne entre nos targets + un offset (Height)
        float averageLegHeight = (RightLeg1Target.transform.position.y + RightLeg2Target.transform.position.y + RightLeg3Target.transform.position.y
            + LeftLeg1Target.transform.position.y + LeftLeg2Target.transform.position.y + LeftLeg3Target.transform.position.y) / 6;
        this.transform.position = new Vector3(this.transform.position.x, averageLegHeight + Height, this.transform.position.z);
    }
}
