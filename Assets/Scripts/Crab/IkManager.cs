using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkManager : MonoBehaviour
{

    // Joint de départ
    public Joint root_joint;

    // Joint d'arrivée
    public Joint end_joint;

    // La position que l'on veut atteindre avec notre end_joint
    public GameObject fixation;

    // Distance minimum entre end_joint et fixation que l'on veut atteindre
    public float m_threshold = 0.05f;

    // rate est un facteur permettant d'accélerer la vitesse rotation des joints
    public float rate = 5.0f;

    // steps permet d'accélerer la vitesse rotation des joints en effectuant les calculs plusieurs fois par Update
    public int steps;

    float CalculateSlope(Joint joint)
    {
        // delta est la valeur de notre rotation
        float delta = 0.01f;

        float distance = GetDistance(end_joint.transform.position, fixation.transform.position);

        joint.Rotate(delta);

        float rotatedDistance = GetDistance(end_joint.transform.position, fixation.transform.position);

        joint.Rotate(-delta);

        // On retourne la valeur de notre pente
        return (rotatedDistance - distance) / delta;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < steps; i++)
        {
            if (GetDistance(end_joint.transform.position, fixation.transform.position) > m_threshold)
            {
                Joint current = root_joint;
                while (current != null)
                {
                    // On calcule la valeur de notre pente qui nous indique
                    // a quel point notre end_joint est éloigné de notre fixation
                    float slope = CalculateSlope(current);

                    // On pivote notre joint en fonction de la valeur de notre pente
                    current.Rotate(-slope * rate);

                    // Faire ça sur le Joint suivant
                    current = current.GetChild();
                }

            }
        }
    }

    float GetDistance(Vector3 point1, Vector3 point2)
    {
        return Vector3.Distance(point1, point2);
    }
}
