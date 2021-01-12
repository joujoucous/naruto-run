using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    // Distance d'éloignement maximum entre nos fixations et nos targets
    public float fixation_threshold = 2.0f;

    // Vitesse de déplacement de notre crabe 
    public float speed;

    public GameObject RightLeg1Fixation;
    public GameObject RightLeg1Target;
    public GameObject RightLeg2Fixation;
    public GameObject RightLeg2Target;
    public GameObject RightLeg3Fixation;
    public GameObject RightLeg3Target;
    public GameObject LeftLeg1Fixation;
    public GameObject LeftLeg1Target;
    public GameObject LeftLeg2Fixation;
    public GameObject LeftLeg2Target;
    public GameObject LeftLeg3Fixation;
    public GameObject LeftLeg3Target;

    // Update is called once per frame
    void Update()
    {
        // On fait avancer notre crabe a droite
        this.transform.Translate(Vector3.right * Time.deltaTime * speed);

        // On fait bouger les fixations de nos Legs si elles sont éloignées
        MoveFixation(RightLeg1Fixation, RightLeg1Target);
        MoveFixation(RightLeg2Fixation, RightLeg2Target);
        MoveFixation(RightLeg3Fixation, RightLeg3Target);
        MoveFixation(LeftLeg1Fixation, LeftLeg1Target);
        MoveFixation(LeftLeg2Fixation, LeftLeg2Target);
        MoveFixation(LeftLeg3Fixation, LeftLeg3Target);
    }

    // Fait les fixations de nos Legs si elles sont éloignées
    void MoveFixation(GameObject LegFixation, GameObject LegTarget)
    {
        if (GetDistance(LegFixation.transform.position, LegTarget.transform.position) > fixation_threshold)
        {
            LegFixation.transform.position = LegTarget.transform.position;
        }
    }

    float GetDistance(Vector3 point1, Vector3 point2)
    {
        return Vector3.Distance(point1, point2);
    }
}
